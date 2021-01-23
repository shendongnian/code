    [Test]
    public void SerializationPerhaps()
    {
        var charlie = new Dictionary();
        Dictionary delta = null;
        // Borrowed from MSDN:  http://msdn.microsoft.com/en-us/library/system.serializableattribute.aspx
        //Opens a file and serializes the object into it in binary format.
        using (var stream = File.Open("data.xml", FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, charlie);
        }
        //Opens file "data.xml" and deserializes the object from it.
        using (var stream = File.Open("data.xml", FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            delta = (Dictionary) formatter.Deserialize(stream);
            stream.Close();
        }
        for(int i = 0; i < 10; i++)
        {
            Assert.AreEqual(charlie.GetNext(), delta.GetNext());
        }
    }
