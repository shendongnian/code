        //--------------My Class
        private static MyClass _class = null;
        public static MyClass _Class
        {
            get
            {
                // Delay creation of the view model until necessary
                if (_class == null)
                    _class = new MyClass();
                return _class;
            }
        }
