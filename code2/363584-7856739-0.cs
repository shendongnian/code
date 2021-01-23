        public override int SaveChanges()
        {
            var modified = this.ChangeTracker.Entries().Where(e => e.State == System.Data.EntityState.Modified);
            // set whatever values you want on modified entities
            return base.SaveChanges();
        }
