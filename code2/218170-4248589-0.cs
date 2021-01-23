    public interface IRole : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region ConcurrencyToken
        /// <summary>
        /// Gets the unique binary concurrency token for the security role.
        /// </summary>
        /// <value>
        /// A <see cref="IList{Byte}"/> collection that contains the unique binary concurrency token for the security role.
        /// </value>
        IList<byte> ConcurrencyToken
        {
            get;
        }
        #endregion
    
        #region Description
        /// <summary>
        /// Gets or sets the description of the security role.
        /// </summary>
        /// <value>
        /// The human readable description of the security role.
        /// </value>
        string Description
        {
            get;
            set;
        }
        #endregion
    
        #region Id
        /// <summary>
        /// Gets or sets the unique identifier for the security role.
        /// </summary>
        /// <value>
        /// A <see cref="Int32"/> value that represents the unique identifier for the security role.
        /// </value>
        int Id
        {
            get;
            set;
        }
        #endregion
    
        #region LastModifiedBy
        /// <summary>
        /// Gets or sets the name of the user or process that last modified the security role.
        /// </summary>
        /// <value>
        /// The name of the user or process that last modified the security role.
        /// </value>
        string LastModifiedBy
        {
            get;
            set;
        }
        #endregion
    
        #region LastModifiedOn
        /// <summary>
        /// Gets or sets the date and time at which the security role was last modified.
        /// </summary>
        /// <value>
        /// A <see cref="Nullable{DateTime}"/> that represents the date and time at which the security role was last modified.
        /// </value>
        DateTime? LastModifiedOn
        {
            get;
            set;
        }
        #endregion
    
        #region Name
        /// <summary>
        /// Gets or sets the name of the security role.
        /// </summary>
        /// <value>
        /// The human readable name of the security role.
        /// </value>
        string Name
        {
            get;
            set;
        }
        #endregion
    }
