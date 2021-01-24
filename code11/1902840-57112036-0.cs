    class Program
    {
        string output;
        public void initalize(string findlongestcontainof)
        {
            int length = 0;
            
            List<string> inputs = new List<string>();
            inputs.Add("1->2->3");
            inputs.Add("1->2->3->4");
            inputs.Add("1->2->3->4->5->6");
            inputs.Add("1->2->3->4->5");
            foreach(string s in inputs)
            {
                if(s.Contains(findlongestcontainof))
                {
                    if(s.Length > length)
                    {
                        length = s.Length;
                        output = s;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.initalize("1->2");
            Console.WriteLine(p.output);
            Console.ReadLine();
        }
    }
