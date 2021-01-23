       class NonParallelQuery 
        {
            IEnumerable _data;
            public NonParallelQuery(IEnumerable data)
            {
                _data = data;
    
            }
            public IEnumerator GetEnumerator()
            {
                return _data.GetEnumerator();
            }
        }
    
        static class Extensions
        {
            public static NonParallelQuery AsParallel(this IEnumerable source)
            {
    #if DEBUG
                return new NonParallelQuery(ParallelEnumerable.AsParallel(source));
    #else
                return new NonParallelQuery(source);
    #endif
            }
        }
    
    
        public partial class Form1 : Form
        {
          
            public Form1()
            {
                var data = new string[] { "first", "second" };
                foreach (var str in data.Select(x => x.ToString()).AsParallel())
                {
                    Debug.Print("Value {0}", str);
                }
                InitializeComponent();
            }
