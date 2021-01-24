    public class Parameter
    {
        public string parameterName;
        public string parameterType;
        public override bool Equals(object obj)
        {
            return parameterName == ((Parameter) obj)?.parameterName &&
                   parameterType == ((Parameter) obj)?.parameterType;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = parameterName != null ? parameterName.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (parameterType != null ? parameterType.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
