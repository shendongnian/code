    public class TBase
    {
        public int Prop { get; set; }
    }
    public class TChildOne : TBase
    {
    }
    public class TChildTwo : TBase
    {
    }
    public class GClass
    {
        private List<T> GetAll<T>() where T : TBase
        {
            var listOfTModels = // gets the list of T from the database.
            return listOfTModels;
          }
        public void Main(string strType)
        {
            switch (strType)
            {
                case "TChildOne":
                    {
                        var child = GetAll<TChildOne>();
                        break;
                    }
                case "TChildTwo":
                    {
                        var child = GetAll<TChildTwo>();
                        break;
                    }
                default:
                    throw new Exception("type not found");
            }
        }
    }
