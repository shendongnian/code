    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    List<Person> dbItems = new List<Person>();
    while(myReader.Read())
    {
       Person objPerson = new Person();
       
       objPerson.Name = Convert.ToString(myReader["Name"]);
       objPerson.Age = Convert.ToInt32(myReader["Age"]);
       
       dbItems.Add(objPerson);
    }
