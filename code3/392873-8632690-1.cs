    Customer customer = new Customer();
    customer.FullName = "John"; // or customer.FullName = textBox1.Text
    customer.Age = "21"; // or customer.Age = textBox2.Text
    
    XmlSerializer serializer = new XmlSerializer(typeof(Customer));
    TextWriter textWriter = new StreamWriter(@"D:\customer.xml");
    serializer.Serialize(textWriter, customer);
    textWriter.Close();
