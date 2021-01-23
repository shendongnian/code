        public class Appointment
        {
            [XmlIgnore()]
            public Person MyPerson
            {
                get;
                set;
            }
            public int MyPersonId
            {
                get { return MyPerson.Id; }
                set { MyPerson = new Person(value)}
            }
        }
