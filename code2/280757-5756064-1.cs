    public class IndexViewModel
    {
        public  int value { get; set; }
       public   List<System.Web.Mvc.SelectListItem> items { get; set; }
    }
    
    public class Index
    {
        public int value { get; set; }
    }
    
    
    class DropDownList
    {
       public List<System.Web.Mvc.SelectListItem> GetDropDownList()
       {
           List<System.Web.Mvc.SelectListItem> result = new List<System.Web.Mvc.SelectListItem>();
           result.Add(new System.Web.Mvc.SelectListItem
           {
               Value = "1",
               Text = "Apple"
           });
           result.Add(new System.Web.Mvc.SelectListItem
           {
               Value = "2",
               Text = "Milk"
           });
           return result;
       }
    }
