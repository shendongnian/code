    public class AppDbContext : DbContext
    {
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEntityValidationException)
            {
                throw ExceptionHelper.CreateFromEntityValidation(dbEntityValidationException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw ExceptionHelper.CreateFromDbUpdateException(dbUpdateException);
            }
        }   
           
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbEntityValidationException dbEntityValidationException)
            {
                throw ExceptionHelper.CreateFromEntityValidation(dbEntityValidationException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw ExceptionHelper.CreateFromDbUpdateException(dbUpdateException);
            }
        }
