    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        Public Customer (string Name, string ID)
        {
            this.Name = Name; //this.Name is class'es Name and Name is the constructor's parameter Name
            this.ID = ID; // Same for the ID
        }
    }
       
