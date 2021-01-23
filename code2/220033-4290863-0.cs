    public class Parent
    {
        public string ParentProp { get; set; }
    }
    
    public class Child: Parent
    {
        public string ChildProp { get; set; }
    }
    
    public class CustomResolver : JavaScriptTypeResolver
    {
        public override Type ResolveType(string id)
        {
            return Type.GetType(id);
        }
    
        public override string ResolveTypeId(Type type)
        {
            return type.ToString();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var o = new Child
            {
                ParentProp = "parent prop",
                ChildProp = "child prop",
            };
    
            var serializer = new JavaScriptSerializer(new CustomResolver());
            var s = serializer.Serialize(o);
            Console.WriteLine(s);
        }
    }
