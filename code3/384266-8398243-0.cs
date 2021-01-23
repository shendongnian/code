     public static class ThirdPartyResultExtension
      {
        public static ArrayList ResultsAsArrayList(this ThirdPartyResult d)
        {
          ArrayList list = new ArrayList();
          list.AddRange(d.Result);
          return list;
        }
        
      }
      
      public class ThirdPartyResult
      {
        private IList result;
    
        public IList Result
        {
          get { return result ?? (result = new ArrayList()); }
        }
      }
