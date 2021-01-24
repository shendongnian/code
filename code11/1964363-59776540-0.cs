    class ValueGenerator : Microsoft.EntityFrameworkCore.ValueGeneration.ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;
    
        protected override object NextValue(EntityEntry entry) => ((MyEntity) entry.Entity).GetValue();
    }
