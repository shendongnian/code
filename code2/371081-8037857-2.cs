    char sep = '■';  //whatever. copy/paste with care. 
    XElement lastStudent = null, lastDegrees = null;
    foreach (var line in lineCollection)
    {
        string[] parts = line.Split(sep);
        int leading = parts.TakeWhile(s => s == "").Count();
        if (leading == 0)  // Student
        {
            // todo: validate parts.length, part[0]
 
            lastStudent = new XElement("Student",
                new XAttribute("name", parts[1]),
                new XAttribute("surname", parts[2]));
  
            doc.Root.Add(lastStudent);            
        }
        else if (leading == 1)  // Subject
        {
            // todo: validate 
            lastDegrees = new XElement("degrees",
                     parts.Skip(2).Select(p => new XElement("degree", p)) );
            lastStudent.Add(new XElement(parts[1], lastDegrees);               
        }
        else ...
    }
