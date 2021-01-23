    $source =@"
    using System.Collections.Generic;
    public class MyClass {
        public List<string> MyList;
        public MyClass(){
        MyList = new List<string>();
        }
    }
    
    "@
    
    Add-Type -TypeDefinition $source -Language CSharpVersion3
    
    $myObject = new-object MyClass
    
    $myObject.MyList.Add("test");
    
    $myObject.MyList.Count
