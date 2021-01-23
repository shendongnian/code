    public class MyForm: Form
    {
       public MyForm()
       {
          if(!DesignMode) throw new InvalidOperationException("Cannot use default constructor in production code");
       }
    
       public MyForm(MyDependency dependent)
       {
          ...
       }
    }
