        class MyThing
        {
            public string Text { get; private set; }
            public int Version { get; private set; }
            public MyThing(string t, int v)
            {
                Text = t;
                Version = v;
            }
            public override int  GetHashCode()
            {
 	             return Text.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                MyThing other = obj as MyThing;
                if (other == null)
                    return false;
                return this.Text.Equals(other.Text);
            }
        }
        static List<MyThing> oldList = new List<MyThing>()
        {
            new MyThing("Foo", 0),
            new MyThing("Bar", 0),
            new MyThing("Fooby", 0),
        };
        static List<MyThing> newList = new List<MyThing>()
        {
            new MyThing("Barby", 1),
            new MyThing("Bar", 1)
        };
        static void DoIt()
        {
            var unionOldNew = oldList.Union(newList);
            Console.WriteLine("oldList.Union(newList)");
            foreach (var t in unionOldNew)
            {
                Console.WriteLine("{0}, {1}", t.Text, t.Version);
            }
            Console.WriteLine();
            var unionNewOld = newList.Union(oldList);
            Console.WriteLine("newList.Union(oldList)");
            foreach (var t in unionNewOld)
            {
                Console.WriteLine("{0}, {1}", t.Text, t.Version);
            }
        }
