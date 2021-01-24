c#
    /// <summary>
    /// It's a marker interface, in order to make our entities audit-able.
    /// Every entity you mark with this interface, will save audit info to the database.
    /// </summary>
    public interface IAuditableEntity
    { }
    
2- Create a static Class to write your Shadow Properties logic. `AuditableShadowProperties.cs`
c#
public static class AuditableShadowProperties {
    public static readonly Func<object, DateTimeOffset?> EfPropertyCreatedDateTime =
        entity => EF.Property<DateTimeOffset?> (entity, CreatedDateTime);
    public static readonly string CreatedDateTime = nameof (CreatedDateTime);
    public static readonly Func<object, DateTimeOffset?> EfPropertyModifiedDateTime =
        entity => EF.Property<DateTimeOffset?> (entity, ModifiedDateTime);
    public static readonly string ModifiedDateTime = nameof (ModifiedDateTime);
    public static void AddAuditableShadowProperties (this ModelBuilder modelBuilder) {
        foreach (var entityType in modelBuilder.Model
                .GetEntityTypes ()
                .Where (e => typeof (IAuditableEntity).IsAssignableFrom (e.ClrType))) {
            modelBuilder.Entity (entityType.ClrType)
                .Property<DateTimeOffset?> (CreatedDateTime);
            modelBuilder.Entity (entityType.ClrType)
                .Property<DateTimeOffset?> (ModifiedDateTime);
        }
    }
    public static void SetAuditableEntityPropertyValues (
        this ChangeTracker changeTracker) {
        var now = DateTimeOffset.UtcNow;
        var modifiedEntries = changeTracker.Entries<IAuditableEntity> ()
            .Where (x => x.State == EntityState.Modified);
        foreach (var modifiedEntry in modifiedEntries) {
            modifiedEntry.Property (ModifiedDateTime).CurrentValue = now;
        }
        var addedEntries = changeTracker.Entries<IAuditableEntity> ()
            .Where (x => x.State == EntityState.Added);
        foreach (var addedEntry in addedEntries) {
            addedEntry.Property (CreatedDateTime).CurrentValue = now;
        }
    }
}
3- Add neccessery changes to your `PersonDbContext` to use your `IAuditableEntity`.
c#
 // first we add our shadow properties to the database with next migration
 protected override void OnModelCreating(ModelBuilder builder)
{
...
  builder.AddAuditableShadowProperties();
}
// override saveChanges methods to use our shadow properties.
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled =
                false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
     public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled =
                false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            BeforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled =
                false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        #region "ExtraMethods"
        public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
        {
            var value = this.Entry(entity).Property(propertyName).CurrentValue;
            return value != null ?
                (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture) :
                default(T);
        }
        public object GetShadowPropertyValue(object entity, string propertyName)
        {
            return this.Entry(entity).Property(propertyName).CurrentValue;
        }
        private void BeforeSaveTriggers()
        {
            ValidateEntities();
            SetShadowProperties();
        }
        private void ValidateEntities()
        {
            var errors = this.GetValidationErrors();
            if (!string.IsNullOrWhiteSpace(errors))
            {
                // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
                var loggerFactory = this.GetService<ILoggerFactory>();
                loggerFactory.CheckArgumentIsNull(nameof(loggerFactory));
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(errors);
                throw new InvalidOperationException(errors);
            }
        }
        private void SetShadowProperties()
        {
            ChangeTracker.SetAuditableEntityPropertyValues();
        }
        #endregio
**usage:**
4- now you can add `IAuditableEntity` interface to any entity you want to have these shadow properties and you are done.
c#
public class Person : IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
I'm using `IAuditableEntity` with a lot of other properties such as `BrowserName` `userIp` ... but I removed those in this example to keep it as simple as possible. it's not easy to explain everything in this example but feel free to ask if you had any questions about this approach.
