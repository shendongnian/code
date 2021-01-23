    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath(Request.ApplicationPath + "/test.xml");
        List<Person> people = File.Exists(path) ? Deserialize(path)
                                                : new List<Person>();
        people.Add(new Person(TextBox1.Text, TextBox2.Text,
                              int.Parse(TextBox3.Text));
        using (FileStream fs = File.OpenWrite(path))
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
            ser.Serialize(fs, o);
        }
    }
