        public static bool operator !=(ExpiryMonth em1, ExpiryMonth em2)
        {
            if (((object)em1) == null || ((object)em2) == null)
            {
                return !Object.Equals(em1, em2);
            }
            else
            {
                return !(em1.Equals(em2));
            }
        }
        public static bool operator ==(ExpiryMonth em1, ExpiryMonth em2)
        {
            if (((object)em1) == null || ((object)em2) == null)
            {
                return Object.Equals(em1, em2);
            }
            else
            {
                return em1.Equals(em2);
            }
        }
        public bool Equals(ExpiryMonth other)
        {
            if (other == null) { return false; }
            return Year == other.Year && Month == other.Month;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            ExpiryMonth em = obj as ExpiryMonth;
            if (em == null) { return false; }
            else { return Equals(em); }
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is not a problem
            {
                var result = 17;
                result = (result * 397) + Year.GetHashCode();
                result = (result * 397) + Month.GetHashCode();
                return result;
            }
        }
