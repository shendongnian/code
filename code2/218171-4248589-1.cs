    public class Role : EntityBase, IRole, IEquatable<Role>
    {
        //=======================================================================================================
        //	Constructors
        //=======================================================================================================
        #region Role()
        /// <summary>
        /// Initializes a new instance of <see cref="Role"/> class.
        /// </summary>
        public Role()
        {
        }
        #endregion
    
        #region Role(IEnumerable<byte> concurrencyToken)
        /// <summary>
        /// Initializes a new instance of <see cref="Role"/> class 
        /// using the specified unique binary concurrency token.
        /// </summary>
        /// <param name="concurrencyToken">The unique binary concurrency token for the security role.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="concurrencyToken"/> is a <see langword="null"/> reference (Nothing in Visual Basic).</exception>
        public Role(IEnumerable<byte> concurrencyToken) : base(concurrencyToken)
        {
                
        }
        #endregion
    
        //=======================================================================================================
        //	Public Methods
        //=======================================================================================================
        #region ToString()
        /// <summary>
        /// Returns a <see cref="String"/> that represents the current <see cref="Role"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> that represents the current <see cref="Role"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }
        #endregion
    
        //=======================================================================================================
        //	IEquatable<Role> Implementation
        //=======================================================================================================
        #region Equals(Role other)
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
        public bool Equals(Role other)
        {
            if (other == null)
            {
                return false;
            }
    
            if (!String.Equals(this.Description, other.Description, StringComparison.Ordinal))
            {
                return false;
            }
            else if (!Int32.Equals(this.Id, other.Id))
            {
                return false;
            }
            else if (!String.Equals(this.Name, other.Name, StringComparison.Ordinal))
            {
                return false;
            }
    
            return true;
        }
        #endregion
    
        #region Equals(object obj)
        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current <see cref="Object"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the specified <see cref="Object"/> is equal to the current <see cref="Object"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Role);
        }
        #endregion
    
        #region GetHashCode()
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        /// <a href="http://msdn.microsoft.com/en-us/library/system.object.gethashcode.aspx"/>
        public override int GetHashCode()
        {
            int descriptionHashCode     = this.Description.GetHashCode();
            int idHashCode              = this.Id.GetHashCode();
            int nameHashCode            = this.Name.GetHashCode();
    
            /*
                * The 23 and 37 are arbitrary numbers which are co-prime.
                * 
                * The benefit of the below over the XOR (^) method is that if you have a type 
                * which has two values which are frequently the same, XORing those values 
                * will always give the same result (0) whereas the above will 
                * differentiate between them unless you're very unlucky.
            */
            int hashCode    = 23;
            hashCode        = hashCode * 37 + descriptionHashCode;
            hashCode        = hashCode * 37 + idHashCode;
            hashCode        = hashCode * 37 + nameHashCode;
                
            return hashCode;
        }
        #endregion
    
        //=======================================================================================================
        //	IRole Implementation
        //=======================================================================================================
        #region Description
        /// <summary>
        /// Gets or sets the description of this security role.
        /// </summary>
        /// <value>
        /// The human readable description of this security role. The default value is an <see cref="String.Empty"/> string.
        /// </value>
        [DataMember()]
        public string Description
        {
            get
            {
                return _roleDescription;
            }
    
            set
            {
                if (PropertyChangeNotifier.AreNotEqual(_roleDescription, value))
                {
                    using (new PropertyChangeNotifier(OnPropertyChanging, OnPropertyChanged))
                    {
                        _roleDescription = !String.IsNullOrEmpty(value) ? value : String.Empty;
                    }
                }
            }
        }
        private string _roleDescription = String.Empty;
        #endregion
    
        #region Id
        /// <summary>
        /// Gets or sets the unique identifier for this security role.
        /// </summary>
        /// <value>
        /// A <see cref="Int32"/> value that represents the unique identifier for this security role. 
        /// The default value is <i>zero</i>.
        /// </value>
        [DataMember()]
        public int Id
        {
            get
            {
                return _roleId;
            }
    
            set
            {
                if (PropertyChangeNotifier.AreNotEqual(_roleId, value))
                {
                    using (new PropertyChangeNotifier(OnPropertyChanging, OnPropertyChanged))
                    {
                        _roleId = value;
                    }
                }
            }
        }
        private int _roleId;
        #endregion
    
        #region Name
        /// <summary>
        /// Gets or sets the name of this security role.
        /// </summary>
        /// <value>
        /// The human readable name of this security role. The default value is an <see cref="String.Empty"/> string.
        /// </value>
        [DataMember()]
        public string Name
        {
            get
            {
                return _roleName;
            }
    
            set
            {
                if (PropertyChangeNotifier.AreNotEqual(_roleName, value))
                {
                    using (new PropertyChangeNotifier(OnPropertyChanging, OnPropertyChanged))
                    {
                        _roleName = !String.IsNullOrEmpty(value) ? value : String.Empty;
                    }
                }
            }
        }
        private string _roleName = String.Empty;
        #endregion
    }
