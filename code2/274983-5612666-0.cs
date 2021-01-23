    public Form2()
        {
            InitializeComponent();
            List<object> objects = new List<object>();
            objects.Add(new Rat("the rat's name"));
            objects.Add(new Elephant("the elephant's name"));
            foreach (object o in objects)
            {
                if(o.GetType() == typeof(Rat))
                {
                    Rat r = o as Rat;
                    Console.WriteLine(
                        string.Format("Name of rat: {0}", r.Name));
                }
                else if(o.GetType() == typeof(Elephant))
                {
                    Elephant e = o as Elephant;
                    Console.WriteLine(
                        string.Format("Name of elephant: {0}", e.Name));
                }
            }
        }
        public class Elephant
        {
            public Elephant(string name)
            {
                this.Name = name;
            }
            public string Name
            {
                get;
                private set;
            }
            public string AnimalProps
            {
                get;
                set;
            }
        }
        public class Rat
        {
            public Rat (string name)
            {
                this.Name = name;
            }
            public string Name
            {
                get;
                private set;
            }
            public string RatProps
            {
                get;
                set;
            }
        }
