    TestClass testClass = new TestClass();
    
       Type type = testClass.GetType();
    
       foreach (PropertyInfo pInfo in type.GetProperties())
       {
           DisplayNameAttribute attr = (DisplayNameAttribute)Attribute.GetCustomAttribute(pInfo, typeof(DisplayNameAttribute));
    
           if (attr !=null)
           {
               MessageBox.Show(attr.DisplayName);   
           }
       }
