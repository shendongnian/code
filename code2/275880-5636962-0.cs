    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            List<Test> list = p.GetList();
        }
        public List<Test> GetList()
        {
            List<Test> ss = new List<Test>();
            ss.Add(new Test("m & mm & mm & mm & mm & mm & mm & m", "m & mm & mm & mm & mm & mm & mm & m"));
            string str = "m & m";
            if (!string.IsNullOrEmpty(str)) 
            { 
                ss = ss.Where(it => (it.SourceCode.ToUpper().Contains(str.ToUpper()) || it.SourceName.ToUpper().Contains(str.ToUpper()))).ToList();
            } 
            
            //if (top > 0) 
            //{
            //    ss = ss.Take(top); 
            //}
            
            return ss.ToList(); 
        }
    }
    public class Test
    {
        public Test(string sourceCode, string sourceName)
        {
            this.SourceCode = sourceCode;
        }
        public string SourceCode
        {
            get;
            set;
        }
        public string SourceName
        {
            get;
            set;
        }
    }
