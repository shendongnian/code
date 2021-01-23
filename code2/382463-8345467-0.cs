        /// <summary>
    /// Base class for common functionality shared across Sql repositories.
    /// </summary>
    internal abstract class BaseSqlRepository : IDisposable
    {
        #region Members
        /// <summary>
        /// Linq to Sql data context
        /// </summary>
        private SqlRepositoryDataContext context;
        /// <summary>
        /// Determines whether the class has invoked the dispose/finalize functionality.
        /// </summary>
        private bool isDisposed;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSqlRepository"/> class.
        /// </summary>
        protected BaseSqlRepository()
        {
            this.context = new SqlRepositoryDataContext(InitializeConnectionString());
            this.isDisposed = false;
        }
        protected BaseSqlRepository(SqlRepositoryDataContext Context)
        {
            this.context = Context;
            this.isDisposed = false;
        }
        /// <summary>
        /// Finalizes an instance of the BaseSqlRepository class.
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="BaseSqlRepository"/> is reclaimed by garbage collection.
        /// </summary>
        ~BaseSqlRepository()
        {
            this.Dispose(false);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        protected SqlRepositoryDataContext Context
        {
            get { return this.context; }
            set { this.context = value; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Initializes the connection string.
        /// </summary>
        /// <returns>Connection string.</returns>
        protected static string InitializeConnectionString()
        {
            string connectionName = ConfigurationManager.AppSettings["AppConnection"];
            string connection = string.Empty;
            if (!string.IsNullOrWhiteSpace(connectionName))
            {
                connection = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                if (string.IsNullOrWhiteSpace(connection))
                {
                    throw new ArgumentException("Unable to initialize a connection to the database.");
                }
            }
            else
            {
                throw new ArgumentException("Unable to initialize a connection to the database.");
            }
            return connection;
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(bool disposing)
        {
            if (!this.isDisposed && disposing)
            {
                // Dispose the managed resources of the class
                this.context.Dispose();
            }
            // Dipose the un-managed resources of the class
            this.isDisposed = true;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
