     public class SimpleViewModel{
         public List<SelectListItem> Status_List {get; set}
         public string Default_Status {get; set}
    
         public SimpleViewModel(){
             CustomerList  = new List<SelectListItem>();
             Default_Status= "Active"; //default value.
    }
