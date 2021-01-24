    public class MyProduct {
       public string Id { get; set; }
    
        public int CustomId { get; set; }
    }
    public static readonly List<MyProduct > MyListOfProducts = new List<MyProduct >()
        {
           new MyProduct(){
               Id = "1",
               CustomId = (int)MyEnum.NameOfService
           },
            new MyProduct(){
               Id = "2",
               CustomId = (int)MyEnum.AgeOfService
           }
        }
