    public class MainViewModel:ViewModelBase,IDataErrorInfo  
    {
     public string Error
      {
      }
    public string this[string columnName]
 
    {
     get
      {
         string msg=nulll;
         switch(columnName)
            {
              case "MyProperty": //that will be your binding property
               //choose your validation logic
               if(MyProperty==0||MyProperty==null)
                 msg="My Property is required";
                break;
             }
         return msg;
        }
    }
