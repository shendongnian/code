    public class Model 
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value & null != value)
                {
                    name = value;
                }
                else
                {
                    name = "Default Value";
                }
            }
        }
    }
