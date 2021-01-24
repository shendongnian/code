    class Program
    {
        static void Main(string[] args)
        {
            #region Create data
    
            using (var context = new ConsoleDbContext())
            {
                context.Add(new Person()
                {
                    Id = 1,
                    Name = "Relatively Random",
                    Animals = new List<Animal>
                        {
                            new Cat {Id= 1, Name = "Relatively" },
                            new Dog {Id = 2, Name = "Random" }
                        },
                    Address = new Address
                    {
                        Street = "Sesame street",
                        City = "London",
                        Country = "United Kingdom"
                    }
                }).State = EntityState.Added;
    
                context.Add(new Person()
                {
                    Id = 2,
                    Name = "Random Relatively",
                    Animals = new List<Animal>
                        {
                            new Cat {Id= 3, Name = "Relatively" },
                            new Dog {Id = 4, Name = "Random" }
                        }
                });
    
                #endregion
    
                #region Save data
    
                context.SaveChanges();
    
                #endregion
    
                // Create empty clone map
                IDictionary<EntityEntry, object> cloneMap = new Dictionary<EntityEntry, object>(context.ChangeTracker.Entries().Count());
    
                Func<Dog> getDogFunc = () => context.Set<Dog>().Last();
    
                // Get entry we want to clone
                var dog = context.Entry(getDogFunc());
    
                // Clone entry
                Dog dogClone = CloneEntity<Dog>(dog, cloneMap);
    
                // Change name of tracked entity
                dog.Entity.Name = "New name";
    
                // Compare against entity entry entity value and entity itself(which is non sense as those are same reference, but just to be sure it works
                var result = (dogClone.Name == dog.Entity.Name) || (dogClone.Name == getDogFunc().Name);
            }
        }
 
        public static TEntity CloneEntity<TEntity>(EntityEntry entityEntry, IDictionary<EntityEntry, object> cloneMap)
            where TEntity : class
        {
            if (entityEntry == null)
            {
                throw new ArgumentNullException(nameof(entityEntry));
            }
    
            if (cloneMap is null)
            {
                throw new ArgumentNullException(nameof(cloneMap));
            }
    
            //Try get existing clone
            if (cloneMap.TryGetValue(entityEntry, out var clone))
            {
                return (TEntity)clone;
            }
    
            var cloneMapConstant = Expression.Constant(cloneMap);
            var entityEntryType = typeof(EntityEntry);
            var bindings = new List<MemberBinding>(typeof(TEntity).GetProperties().Length);
            var entryParameter = Expression.Parameter(entityEntryType, "entry");
    
            // Create property binding expressions e.g. Name = entry.Entity.Name
            bindings.AddRange(CreatePropertyBinding<TEntity>(ref entityEntry, ref entryParameter));
            // Create reference binding expression e.g. Owner = new Owner() { ..initialization... }
            bindings.AddRange(CreateReferenceBinding(entityEntry, cloneMapConstant));
    
            // Get existing clone or create new one based on binding expressions created earlier 
            var result = GetOrCreateNewEntity<TEntity>(ref entityEntry, ref entryParameter, ref bindings);
    
            cloneMap.Add(entityEntry, result);
    
            return result;
        }
    
        private static TEntity GetOrCreateNewEntity<TEntity>(ref EntityEntry entityEntry, ref ParameterExpression entryParameter, ref List<MemberBinding> bindings)
            where TEntity : class
        {
            // new TEntity()
            var newEntity = Expression.New(typeof(TEntity));
    
            // new TEntity() { ...initialization...  }
            var initilizer = Expression.MemberInit(newEntity, bindings);
    
            // entry => new TEntity() { ...initialization...  }
            var lambda = Expression.Lambda(initilizer, entryParameter);
    
            // Compile expression to function
            var function = lambda.Compile();
    
            // Invoke function and cast result
            var result = (TEntity)function.DynamicInvoke(entityEntry);
    
            // Return result
            return result;
        }
    
        private static IEnumerable<MemberBinding> CreateCollectionBinding(EntityEntry entityEntry, ConstantExpression cloneMapConstant)
        {
            // Get all collection properties
            var collections = entityEntry
                .Collections;
            //.Where(n => n.IsLoaded);
    
            var cloneEntityMethod = typeof(Program).GetMethod(nameof(CloneEntity));
    
            foreach (var collection in collections)
            {
                // ICollection<SomeType>
                var clrType = collection.Metadata.ClrType;
    
                var elementType = clrType.GenericTypeArguments[0];
    
                var hashSetType = typeof(HashSet<>).MakeGenericType(elementType);
    
                // new HashSet<SomeType>()
                var hashSet = Expression.New(hashSetType);
    
                var converted = Expression.TypeAs(hashSet, clrType);
    
                var result = Expression.Bind(collection.Metadata.PropertyInfo, converted);
    
                yield return result;
            }
        }
    
        private static IEnumerable<EntityEntry> GetCollectionItemEntries(DbContext context, CollectionEntry collection)
        {
            foreach (var item in collection.CurrentValue)
            {
                yield return context.Entry(item);
            }
        }
    
        private static IEnumerable<MemberBinding> CreateReferenceBinding(EntityEntry entityEntry, ConstantExpression cloneMapConstant)
        {
            var references = entityEntry
                .References
                .Where(n => n.IsLoaded);
    
            var result = new List<MemberBinding>(references.Count());
    
            var cloneEntityMethod = typeof(Program).GetMethod(nameof(CloneEntity));
    
            foreach (var reference in references)
            {
                var referenceEntityEntry = Expression.Constant(reference.EntityEntry.Context.Entry(reference.TargetEntry.Entity));
    
                var genericCloneEntityMethod = cloneEntityMethod.MakeGenericMethod(reference.Metadata.ClrType);
    
                var callCloneEntityMethod = Expression.Call(null, genericCloneEntityMethod, new Expression[] { referenceEntityEntry, cloneMapConstant });
    
                yield return Expression.Bind(reference.Metadata.PropertyInfo, callCloneEntityMethod);
            }
        }
    
        private static IEnumerable<MemberAssignment> CreatePropertyBinding<TEntity>(ref EntityEntry entityEntry, ref ParameterExpression parameter)
        {
            var entityEntryType = parameter.Type.GetProperty(nameof(EntityEntry.Entity), typeof(object));
            var entityProperty = Expression.MakeMemberAccess(parameter, entityEntryType);
            var convertedEntity = Expression.Convert(entityProperty, typeof(TEntity)); ;
    
            var result = entityEntry
                .Properties
                .Where(p => p.Metadata.IsShadowProperty() == false)
                .Select(p => Expression.Bind(p.Metadata.PropertyInfo, Expression.MakeMemberAccess(convertedEntity, p.Metadata.PropertyInfo)));
    
            return result;
        }
    }
    
    public class ConsoleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("inmemory");
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Owned<Address>();
    
            modelBuilder.Entity<Person>(person =>
            {
                person.HasKey(e => e.Id);
                person.Property(e => e.Name);
                person.OwnsOne(e => e.Address);
            });
    
            modelBuilder.Entity<Animal>(animal =>
            {
                animal.HasKey(e => e.Id);
                animal.HasDiscriminator();
                animal.Property(e => e.Name);
                animal.HasOne(e => e.Owner)
                    .WithMany(e => e.Animals);
            });
    
            modelBuilder.Entity<Dog>(dog =>
            {
                dog.HasBaseType<Animal>();
            });
    
            modelBuilder.Entity<Cat>(cat =>
            {
                cat.HasBaseType<Animal>();
            });
        }
    }
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    
    public abstract class Animal : Entity<int>
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
    
    public class Cat : Animal
    {
    }
    
    public class Dog : Animal
    {
    }
    
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
    
    public class Person : Entity<int>
    {
        public Person()
        {
            //Animals = new HashSet<Animal>();
        }
    
        public string Name { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
