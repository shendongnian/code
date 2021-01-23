    public class ThrowExceptionInitializer : IDatabaseInitializer<Context>
    {
        public InitializeDatabase(Context context)
        {
            // Custom exception
            throw new InvalidVersionException("The new application version is not supported by the database version");
        }
    }
