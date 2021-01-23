    public class MyClass{  
      public List<MyClass> Children {get;set;}  
      public MyClass Parent {get;set;}  
    
      public void ClearParents(){  
        this.Parent = null;  
        this.Children.ForEach(e => e.ClearParents());  
      }  
    }
