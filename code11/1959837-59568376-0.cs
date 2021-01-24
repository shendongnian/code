c#
    public class Person
    {
        public string FullName { get; private set; }
        public int PhoneNumber { get; private set; }
        public int CarQTY { get; private set; }
        public Person(string fullName, int phone, int carQty){
            FullName = fullName;
            PhoneNumber = phone;
            CarQTY = carQty;
        }
    }
The setters might also be public, if you want to allow the modification of the object once it has been created.
