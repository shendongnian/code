    class Program
    {
        static void Main(string[] args)
        {
            //Add values
            List<objClass> lst1 = new List<objClass>();
            for (int i = 0; i < 9000000; i++)
            {
                lst1.Add(new objClass("1", ""));
            }
            //For loop
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < 9000000; i++)
            {
                lst1[i]._s1 = lst1[i]._s2;
            }
            Console.WriteLine((DateTime.Now - startTime).ToString());
            //ForEach Action
            startTime = DateTime.Now;
            lst1.ForEach(s => { s._s1 = s._s2; });
            Console.WriteLine((DateTime.Now - startTime).ToString());
            //foreach normal loop
            startTime = DateTime.Now;
            foreach (objClass s in lst1)
            {
                s._s1 = s._s2;
            }
            Console.WriteLine((DateTime.Now - startTime).ToString());
        }
        public class objClass
        {
            public string _s1 { get; set; }
            public string _s2 { get; set; }
            public objClass(string _s1, string _s2)
            {
                this._s1 = _s1;
                this._s2 = _s2;
            }
        }
    }
