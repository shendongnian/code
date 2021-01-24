    [DataContract]
    public class Student
    {
        private string firstName;
        private string lastName;
        
        private Dictionary<string, string> books = new Dictionary<string, string>();
        [DataMember]
        public Dictionary<string, string> Books
        {
            get => books;
            set => books = value;
        }
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                }
            }
        }
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                }
            }
        }
    }
    var serializer = new DataContractSerializer(typeof(Student));
                using (var sw = new StringWriter()){
                    using (var writer = new XmlTextWriter(sw))
                    {
                        serializer.WriteObject(writer, student);
                        writer.Flush();
                        var xml = sw.ToString();
                    }
                }
