    class Program
    {
        private static Dictionary<Type, Func<object, uint>> _typeMap 
            = new Dictionary<Type, Func<object, uint>>();
    
        static void Main(string[] args)
        {
            RegisterType<Post>(p => p.PostId);
    
            Post myPost = new Post();
            myPost.PostId = 4;
            var i = GetObjectId(myPost);
    
            Console.WriteLine(i);
            Console.ReadKey();
    
        }
    }
