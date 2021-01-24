    public class PersonDto
    {
        public string Name {get; }
        public string Address { get;}
       
        public PersonDto(string name, string address)
        {
           Name = name;
           Address = address;
        }
    }
