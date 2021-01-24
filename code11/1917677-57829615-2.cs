    ````CSharp
    public class MyAuditContext : DbContext
    {
        public MyAuditContext(DbContextOptions<MyAuditContext> options) : base(options)
        {
        }
        private readonly Type[] AllowedTypes = new Type[] 
        { 
            typeof(bool),
            typeof(int),
            typeof(decimal),
            typeof(string),
            typeof(DateTime),
        };
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine($"Generating dynamic audit model");
            //Go through each of the types in Hsa.Engine.Data.Models
            var asm = Assembly.GetExecutingAssembly();
            var modelTypes = asm.GetTypes()
                .Where(type => type.Namespace == "My.Data.Models.Namespace");
            //Create an entity For each type get all the properties on the model
            foreach(var model in modelTypes.Where(t => t.IsClass && !t.IsAbstract && t.BaseType == typeof(AuditInfo)))
            {
                Console.WriteLine($"Creating entity for {model.Name}");
                
                var table = modelBuilder.Entity(model, entity => 
                {
                    //Remove all types from base model, otherwise we get a bunch of noise about foreign keys, etc.
                    foreach(var prop in model.GetProperties())
                    {
                        entity.Ignore(prop.Name);
                    }
                    foreach(var prop in model.GetProperties().Where(p => AllowedTypes.Any(t => p.PropertyType.IsAssignableFrom(t))))
                    {
                        Console.WriteLine($"   Adding field: {prop.Name} - Type: {prop.PropertyType.Name}");
                        //Create a typed field for each property, not including ID or foreign key annotations (do include field lengths)
                        
                        var dbField = entity.Property(prop.PropertyType, prop.Name);
                        if(prop.PropertyType.IsEnum)
                        {
                            dbField.HasConversion<string>();
                        }
                        
                        if(dbField.Metadata.IsPrimaryKey())
                        {
                            dbField.ValueGeneratedNever(); //Removes existing model primary keys for the audit DB
                        }
                    }
                    //Add audit properties
                    entity.Property<int>("AuditId").IsRequired().UseSqlServerIdentityColumn();
                    entity.Property<DateTime>("AuditDate").HasDefaultValueSql("getdate()");
                    entity.Property<string>("DatabaseAction"); //included on AuditInfo but NotMapped to avoid putting it on the main DB. Added here to ensure it makes it into the audit DB
                    entity.HasKey("AuditId");
                    entity.HasIndex("Id");
                    entity.ToTable("Audit_" + model.Name);
                });
            }
            base.OnModelCreating(modelBuilder);
        }
    }
    ````
