     public abstract class Animal
        {
    
            private string name;
    
            public Animal(string name)
            {
    
                this.Name = name;
            }
    
            public Animal() { }
            public string Name
            {
    
                get { return this.name; }
    
                set { this.name = value; }
    
            }
    
            public virtual void talk()
            {
    
                Console.WriteLine("Hi,I am  an animal");
    
            }
    
    
        }
