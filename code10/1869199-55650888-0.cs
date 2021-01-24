using System.Runtime.Serialization;
    [DataContract]
    public class CaseInsensitiveString : IEquatable<CaseInsensitiveString>,
                                         IComparable<CaseInsensitiveString>
    {
        #region Constructors
        public CaseInsensitiveString(string value)
        {
            this.Value = value;
        }
        #endregion
        #region Instance Properties
        
        [DataMember]
        public string Value
        {
            get;
            set;
        }
        #endregion
        #region Instance Methods
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null,
                                obj))
            {
                return false;
            }
            if (ReferenceEquals(this,
                                obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals((CaseInsensitiveString)obj);
        }
        public override int GetHashCode()
        {
            return this.Value != null
                       ? this.Value.GetHashCode()
                       : 0;
        }
        public int CompareTo(CaseInsensitiveString other)
        {
            return string.Compare(this.Value,
                                  other?.Value,
                                  StringComparison.OrdinalIgnoreCase);
        }
        public bool Equals(CaseInsensitiveString other)
        {
            if (ReferenceEquals(null,
                                other))
            {
                return false;
            }
            if (ReferenceEquals(this,
                                other))
            {
                return true;
            }
            return string.Equals(this.Value,
                                 other.Value,
                                 StringComparison.OrdinalIgnoreCase);
        }
        #endregion
        #region Class Methods
        public static bool operator ==(CaseInsensitiveString left,
                                       CaseInsensitiveString right)
        {
            return Equals(left,
                          right);
        }
        public static implicit operator CaseInsensitiveString(string value)
        {
            return new CaseInsensitiveString(value);
        }
        public static implicit operator string(CaseInsensitiveString caseInsensitiveString)
        {
            return caseInsensitiveString.Value;
        }
        public static bool operator !=(CaseInsensitiveString left,
                                       CaseInsensitiveString right)
        {
            return !Equals(left,
                           right);
        }
        #endregion
    }
