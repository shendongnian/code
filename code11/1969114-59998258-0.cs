        /// <summary>
        /// Database abstraction for a combined <see cref="DbContext"/> using ASP.NET 
        ///Identity and Identity Server.
        /// </summary>
        /// <typeparam name="TUser"></typeparam>
        /// <typeparam name="TRole"></typeparam>
        /// <typeparam name="TKey">Key of the IdentityUser entity</typeparam>
        public class KeyApiAuthorizationDbContext<TUser, TRole, TKey> : 
        IdentityDbContext<TUser, TRole, TKey>, IPersistedGrantDbContext
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        {
            private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;
            /// <summary>
            /// Initializes a new instance of <see cref="ApiAuthorizationDbContext{TUser, 
            ///TRole, TKey}"/>.
            /// </summary>
            /// <param name="options">The <see cref="DbContextOptions"/>.</param>
            /// <param name="operationalStoreOptions">The <see 
            ///cref="IOptions{OperationalStoreOptions}"/>.</param>
            public KeyApiAuthorizationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options)
            {
                _operationalStoreOptions = operationalStoreOptions;
            }
            /// <summary>
            /// Gets or sets the <see cref="DbSet{PersistedGrant}"/>.
            /// </summary>
            public DbSet<PersistedGrant> PersistedGrants { get; set; }
            /// <summary>
            /// Gets or sets the <see cref="DbSet{DeviceFlowCodes}"/>.
            /// </summary>
            public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
            Task<int> IPersistedGrantDbContext.SaveChangesAsync() => 
                    base.SaveChangesAsync();
            /// <inheritdoc />
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
            }
        }
        /// <summary>
        /// Database abstraction for a combined <see cref="DbContext"/> using ASP.NET 
        ///Identity and Identity Server.
        /// </summary>
        /// <typeparam name="TUser"></typeparam>
        public class ApiAuthorizationDbContext<TUser> : 
        KeyApiAuthorizationDbContext<TUser, IdentityRole, string>
        where TUser : IdentityUser
        {
            /// <summary>
            /// Initializes a new instance of <see 
            ///cref="ApiAuthorizationDbContext{TUser}"/>.
            /// </summary>
            /// <param name="options">The <see cref="DbContextOptions"/>.</param>
            /// <param name="operationalStoreOptions">The <see 
            ///cref="IOptions{OperationalStoreOptions}"/>.</param>
            public ApiAuthorizationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
            {
            }
        }
       
