            XDocument xTasks = new XDocument();
            XElement xRoot = new XElement("tasklist",
                new XAttribute("timestamp",lastUpdated),
                new XElement("lasttask",lastTask)
            );
            ...
            xTasks.Add(xRoot);
            xTasks.Save("tasks.xml");
            // read it straight in, write it straight back out. Done.
            string[] lines = File.ReadAllLines("tasks.xml"));
            File.WriteAllLines("tasks.xml"),lines);
