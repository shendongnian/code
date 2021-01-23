    public class MyClass
    {
        public int MyModules{ get; set; }
         
    }
    
    2) Now in the Main Block 
      List<MyClass> lstObj = new List<MyClass>();           
    // add the modules one by one 
      MyClass obj = new MyClass();
      obj.MyModules= // your code to add modules
    lstObj.add(obj);
    // after your logic and filling the List.
    gridView1.datasource = lstObj;
    gridView1.databind();
    
    its done now.
                
