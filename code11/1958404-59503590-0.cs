    public class Parameter
    {
        public string parameterName;
        public string parameterType;
        public override bool Equals(object obj)
        {
            return parameterName == ((Parameter) obj)?.parameterName &&
                   parameterType == ((Parameter) obj)?.parameterType;
        }
    }
