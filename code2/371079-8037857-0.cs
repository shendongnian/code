    char sep = '■';  //whatever. copy/paste with care. 
    foreach (var line in lineCollection)
    {
        string[] parts = line.Split(sep);
        int leading = parts.TakeWhile(s => s == "").Count();
        if (leading == 0)  // Student
        {
            // validate part.length == 
            var e = new XElement("Student",
                new XAttribute("name", parts[1]),
                new XAttribute("surname", parts[2]));
  
            doc.Root.Add(e);
            lastStudent = e;
        }
        else if (leading == 1)  // Subject
        {
            ....
        }
    }
