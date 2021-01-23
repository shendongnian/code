    public static class Constant
    {
        public static string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == null)
                    name = value;
                else
                    throw new Exception("...");
            }
        }
        private static string name;
    }
