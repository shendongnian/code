    class Program
    {
        static void Main(string[] args)
        {
            var ss = new List<Dummy> { new Dummy
                         {
                             SourceCode = "m & m",
                             SourceName = "blabla"
                         }}.AsEnumerable();
            string str = "m & m";
            if (!string.IsNullOrEmpty(str))
            {
                ss = ss.Where(it => (it.SourceCode.ToUpper()
                                           .Contains(str.ToUpper())
                                     || it.SourceName.ToUpper()
                                           .Contains(str.ToUpper()))).ToArray();
            }
            var top = 2;
            if (top > 0)
                ss = ss.Take(top).ToArray();
            Console.WriteLine(ss.Count());
        }
    }
    public class Dummy
    {
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
    }
