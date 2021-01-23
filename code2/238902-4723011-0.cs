        public string Test
        {
            get
            {
                //Get properties for this
                System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties( this );
                //Get property descriptor for current property
                System.ComponentModel.PropertyDescriptor pd = pdc[ System.Reflection.MethodBase.GetCurrentMethod().Name ];
            }
        }
