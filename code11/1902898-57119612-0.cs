    string codMapping = "Id"; // get from user
    string nameMapping = "Name"; // get from user
    var overrides = new XmlAttributeOverrides();
    var attrCod = new XmlAttributes();
    var attrName = new XmlAttributes();
    attrCod.XmlElements.Add(new XmlElementAttribute(codMapping));            
    attrName.XmlElements.Add(new XmlElementAttribute(nameMapping));
    overrides.Add(typeof(Student), nameof(Student.cod), attrCod);
    overrides.Add(typeof(Student), nameof(Student.name), attrName);
    var xs = new XmlSerializer(
        typeof(List<Student>), overrides, null, new XmlRootAttribute("Students"), null);
    List<Student> students;
    using (var fs = new FileStream("test.xml", FileMode.Open))
    {
        students = (List<Student>)xs.Deserialize(fs);
    }
    foreach (var s in students)
        Console.WriteLine(s.cod + " " + s.name);
