    public void Import(Street street)
    {
            try
            {
                this.streetContext.Entry(street).State = System.Data.EntityState.Added;
                this.streetContext.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException dbUex)
            {
                this.streetContext.Entry(street).State = System.Data.EntityState.Modified;
                this.streetContext.SaveChanges();
            }
            finally
            {
                ((IObjectContextAdapter)this.streetContext).ObjectContext.Detach(street);
            }
    } 
