    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = new XDocument();
            Add(doc, @"root\cont1", "cont2", "leaf");
            Add(doc.Root, @"cont1\cont1", "cont2", "leaf");
            Add(doc.Root, "cont1", "cont2", "leaf");
            Add(doc.Root, @"cont1\cont1\cont1\cont1", @"cont2\cont2", "leaf");
    
            doc.Save(Console.Out);
        }
        static void Add(XContainer cont, string path1, string path2, string path3)
        {
            Add(cont, path1 + "\\" + path2 + "\\" + path3);
        }
    
        static void Add(XContainer cont, string path)
        {
            Add(cont, path.Split('\\'));
        }
    
        private static void Add(XContainer cont, IEnumerable<string> names)
        {
            XName name = names.FirstOrDefault();
            if (name == null)
            {
                return;
            }
            XContainer child = cont.Element(name);
            if (child == null)
            {
                child = new XElement(name);
                cont.Add(child);
            }
            Add(child, names.Skip(1));
        }
    }
