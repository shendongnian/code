    public class Car
    {
        public Car(Owner owner)
        {
            this.Owner = owner;
        }
        
        //Since Owner is public, you don't have to create a getter method for this. i.e GetOwner()
        public Owner Owner;
    }
    public class Owner
    {
        //Since address is private, you'll have to create a public getter for this
        private string address;
        
        public Owner(string address)
        {
            this.address = address;
        }
   
        //public getter for the address
        public string GetAddress()
        {
            return this.address;
        }
    }
    public class Main
    {
        static void main(string[] args)
        {
            Owner owner1 = new Owner("street address");
            Car car1 = new Car(owner1);
            car1.Owner.GetAddress();
        }
    }
