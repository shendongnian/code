    public class Validate
    {
        public bool IsValid
        {
            get { [implementation here] }
        }
        public static implicit operator bool(Validate v)
        {
            return v.IsValid;
        }
    }
