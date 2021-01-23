    public class FullName : INotifyPropertyChanged, IEquatable<FullName>
    {
        //=======================================================================================================
        //	Constructors
        //=======================================================================================================
        #region FullName()
        public FullName()
        {
    
        }
        #endregion
    
        //=======================================================================================================
        //	Public Properties
        //=======================================================================================================
        #region FirstName
        public string FirstName
        {
            get
            {
                return _firstName;
            }
    
            set
            {
                if (!String.Equals(_firstName, value, StringComparison.Ordinal))
                {
                    _firstName = !String.IsNullOrEmpty(value) ? value.Trim() : String.Empty;
                    this.OnPropertyChanged("FirstName");
                }
            }
        }
        private string _firstName = String.Empty;
        #endregion
    
        #region LastName
        public string LastName
        {
            get
            {
                return _lastName;
            }
    
            set
            {
                if (!String.Equals(_lastName, value, StringComparison.Ordinal))
                {
                    _lastName = !String.IsNullOrEmpty(value) ? value.Trim() : String.Empty;
                    this.OnPropertyChanged("LastName");
                }
            }
        }
        private string _lastName = String.Empty;
        #endregion
    
        #region MiddleName
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
    
            set
            {
                if (!String.Equals(_middleName, value, StringComparison.Ordinal))
                {
                    _middleName = !String.IsNullOrEmpty(value) ? value.Trim() : String.Empty;
                    this.OnPropertyChanged("MiddleName");
                }
            }
        }
        private string _middleName = String.Empty;
        #endregion
    
        //=======================================================================================================
        //	Public Methods
        //=======================================================================================================
        #region Equals(FullName first, FullName second)
        /// <summary>
        /// Determines whether two specified <see cref="FullName"/> objects have the same value.
        /// </summary>
        /// <param name="first">The first role to compare, or <see langword="null"/>.</param>
        /// <param name="second">The second role to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="first"/> object is the same as the value of <paramref name="second"/> object; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool Equals(FullName first, FullName second)
        {
            if (first == null && second != null)
            {
                return false;
            }
            else if (first != null && second == null)
            {
                return false;
            }
            else if (first == null && second == null)
            {
                return true;
            }
            else
            {
                return first.Equals(second);
            }
        }
        #endregion
    
        #region ToString()
        /// <summary>
        /// Returns a <see cref="String"/> that represents the current <see cref="FullName"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> that represents the current <see cref="FullName"/>.
        /// </returns>
        public override string ToString()
        {
            return String.Format(null, "{0}, {1} {2}", this.LastName, this.FirstName, this.MiddleName).Trim();
        }
        #endregion
    
        //=======================================================================================================
        //	IEquatable<FullName> Implementation
        //=======================================================================================================
        #region Equals(FullName other)
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
        public bool Equals(FullName other)
        {
            if (other == null)
            {
                return false;
            }
    
            if (!String.Equals(this.FirstName, other.FirstName, StringComparison.Ordinal))
            {
                return false;
            }
            else if (!String.Equals(this.LastName, other.LastName, StringComparison.Ordinal))
            {
                return false;
            }
            else if (!String.Equals(this.MiddleName, other.MiddleName, StringComparison.Ordinal))
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
            return this.Equals(obj as FullName);
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
            int firstNameHashCode   = this.FirstName.GetHashCode();
            int lastNameHashCode    = this.LastName.GetHashCode();
            int middleNameHashCode  = this.MiddleName.GetHashCode();
    
            /*
                * The 23 and 37 are arbitrary numbers which are co-prime.
                * 
                * The benefit of the below over the XOR (^) method is that if you have a type 
                * which has two values which are frequently the same, XORing those values 
                * will always give the same result (0) whereas the above will 
                * differentiate between them unless you're very unlucky.
            */
            int hashCode    = 23;
            hashCode        = hashCode * 37 + firstNameHashCode;
            hashCode        = hashCode * 37 + lastNameHashCode;
            hashCode        = hashCode * 37 + middleNameHashCode;
                
            return hashCode;
        }
        #endregion
    
        //=======================================================================================================
        //	INotifyPropertyChanged Implementation
        //=======================================================================================================
        #region PropertyChanged
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// The <see cref="PropertyChanged"/> event can indicate all properties on the object have changed 
        /// by using either a <b>null</b> reference (Nothing in Visual Basic) or <see cref="String.Empty"/> 
        /// as the property name in the <see cref="PropertyChangedEventArgs"/>.
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    
        #region OnPropertyChanged(string propertyName)
        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    
        #region OnPropertyChanged(PropertyChangedEventArgs e)
        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="PropertyChangedEventArgs"/> that contains the event data.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
    
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }
