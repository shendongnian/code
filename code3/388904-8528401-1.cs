 public class CommissionModel : IDisposable
    {
        protected PetaPoco.Database db;
        protected OtherResourceType resource2;
        public CommissionModel()
        {
            Boolean ok;
            string connectionString = "Server=localhost;...";
            ok = false;
            try
            {
                // Either of the next two lines may throw an exception
                db = new PetaPoco.Database(connectionString, "mysql");
                resource2 = new OtherResourceType();
                // Once we make it this far, we should be successful
                ok = true;
            }
            finally
            {
                if (!ok)
                  Dispose();
            }
        }
        // Automatically close database connection
        public void Dispose()
        {
            Zap(ref db);  // Method to Dispose and null out, only if not null
            Zap(ref resource2);
        }
    }
