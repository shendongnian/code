    const int child = 0;
    const int father = 1;
    const int grandfather = 2;
    const int greatgrandfather = 3;
    // create your list
    List<Person> persons = new List<Person>();
    // populate it
    persons.Add(new Person(child));
    persons.Add(new Person(father));
    persons.Add(new Person(grandfather));
    persons.Add(new Person(grandgrandfather));
    public class Person : IComparable<Person>
    {
        public int ID { get; set; }
        public Person(int id)
        {
            this.ID = id;
        }
        public Int32 CompareTo(Person right)
        {
            if (this.ID == right.ID)
                return 0;
            if (this.ID > right.ID) return -1;
            else return 1;
        }
    }
