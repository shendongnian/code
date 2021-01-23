    public class MyListBinder : IModelBinder
    {   
         public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
         {   
            string integers = controllerContext.HttpContext.Request["Idl"];
            string [] stringArray = integers.Split(',');
            var list = new List<int>();
            foreach (string s in stringArray)
            {
               list.Add(int.Parse(s));
            }
            return list;  
         }  
    }
    
    public ActionResult GetItems([ModelBinder(typeof(MyListBinder))]List<int> id_list) 
    { 
        return View(); 
    } 
