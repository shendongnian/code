    [DataContract]
    class Student
    {
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public int Age { get; set; }
    }
    
    static void Main(string[] args)
    {
      var serializer = new DataContractJsonSerializer(typeof (Student));
      var student = new Student {Name = "Jonh", Age = 18};
      var stream = new MemoryStream();
      serializer.WriteObject(stream, student);
      var jsonString = Encoding.Default.GetString(stream.ToArray());
    
    }
