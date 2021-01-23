        public void Update(string ac, string pr, string fld, string val) { 
        try 
           { 
               vm.Product = _product.Get(ac, pr);
               if( vm.Product != null)
                 {
                    Type type =  vm.Product.GetType();
                    PropertyInfo pIn = type.GetProperty(fld);
                    if(pIn != null)
                         pIn.SetValue(vm.Product, val, null);
                 }
            }
            catch (Exception e) { log(e); }
         }
