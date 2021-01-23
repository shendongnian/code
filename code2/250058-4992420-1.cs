     public class ViewDataController
     {
        public static IViewData GetViewDataController(string outputMedia, string operation, string study)
        {
          IViewData viewData = null;
          switch (outputMedia)
          {
            case "Excel":
                viewData = new ExcelOutput(operation, study);
                break;
            case "Spotfire":
                viewData = new SpotfireOutput(operation, study);
                break;
          }
          return viewData;
         }
  
  
