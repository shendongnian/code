        //--------------My Class
        private static MyClass _class = null;
        public static MyClass _Class
        {
            get
            {              
                if (_class == null)
                    _class = new MyClass();
                return _class;
            }
        }
