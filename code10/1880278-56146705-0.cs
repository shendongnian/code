    namespace UtiLibrary
    {
        public static class UtiClass
        {
            public static List<Model> datas { get => new List<Model> { new Model { Name = "name" } }; }
        }
    
        public class Model
        {
            public string Name { set; get; }
        }
    }
