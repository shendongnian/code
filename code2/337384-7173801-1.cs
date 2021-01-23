    public class MyClass 
    {
       Dictionary<string, Action> dict = null; 
     
        private Dictionary<string, Action> createView
        {
            get
            {
                if(dict  == null) 
                {
                  dict  = new Dictionary<string, Action>()
                  {
                    {"Standard", CreateStudySummaryView},
                    {"By Group", CreateStudySummaryByGroupView},
                    {"By Group/Time", CreateViewGroupByHour}
                  };
                }
    
                return dict;
            }
        }
       
    }
