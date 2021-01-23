        public string Test
        {
            get
            {
                //Get properties for this
                System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties( this );
                //Get the name of the current getter method ("get_Test")
                string name = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //Extract the property name from the getter method name
                name = name.Split(new char[] {'_'})[1];
                //Get property descriptor for current property
                System.ComponentModel.PropertyDescriptor pd = pdc[ name ];
            }
        }
