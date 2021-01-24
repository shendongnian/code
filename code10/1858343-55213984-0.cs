     class Program
        {
            static void Main(string[] args)
            {
                Owner owner1 = new Owner("street foo city bar");
                Car car1 = new Car(owner1); // this needs to work
    
                Console.WriteLine("Car 1 owner address : " + car1.getOwner().getAddress());
                Console.ReadKey();
    
    
            }
        }
    
    
        class Car
        {
            private Owner owner;  // same here\
            public Car(Owner owner)
            { // use Owner class
                this.owner = owner;
            }
    
            public Owner getOwner() // write a public method to return owner
            {
                return this.owner;
            }
    
    
        }
    
    
        class Owner
        {
           
            private string address; // this 
            public Owner(string address)
            {
              
                this.address = address;
            }
    
            public string getAddress() // write a public method to return address
            {
                return this.address;
            }
        }
