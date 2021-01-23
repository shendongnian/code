    public static void MergeResx(XElement target, string[] sources)
        {
            foreach (string source in sources)
            {
                XElement xe = XElement.Load(source);
                target.Add(new XElement("InternalRoot", new XAttribute("Source", source), from el in xe.Elements()
                                                                                          select el));
            }
            target.Save(@"C:\MergeDone.xml");
        }
