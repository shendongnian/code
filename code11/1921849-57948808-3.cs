    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        Public Customer (string Name, string Id)
        {
            this.Name = Name; //this.Name is class'es Name and Name is the constructor's parameter Name
            this.Id = Id; // Same for the Id
        }
    }
       
