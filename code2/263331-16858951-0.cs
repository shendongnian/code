        public static Map GetTypeInheritance(Type type)
        {
            //get all the interfaces for this type
            var interfaces = type.GetInterfaces();
            //get all the interfaces for the ancestor interfaces
            var baseInterfaces = interfaces.SelectMany(i => i.GetInterfaces());
            //filter based on only the direct interfaces
            var directInterfaces = interfaces.Where(i => baseInterfaces.All(b => b != i));
            Map map = new Map
                {
                    Node = type,
                    Ancestors = directInterfaces.Select(GetTypeInheritance).ToList()
                };
            return map;
        }
        public class Map
        {
           public Type Node { get; set; }
           public List<Map> Ancestors { get; set; }
        }
