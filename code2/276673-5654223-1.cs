    public class AClass
    {
        string Property1 
        { 
            get { return _Property1; }
            set
            {
                if (String.IsNullOrEmpty(_Property1))
                {
                    _Property1 = value
                }
            }
        }
        private string _Property1;
        void AMethod(AClass other)
        {
            this.Property1 = other.Property1;// Property can only be set once.
        }
      
    }
