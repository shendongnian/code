    //Lets suppose Customer is your custom class 
       public class CustomerCollection : CollectionBase 
        { 
            public Customer this[int index] 
            {
                get
                {
                    return (Customer) this.List[index]; 
                } 
                set 
                { 
                    this.List[index] = value;
                }
            }
            public void Add(Customer customer)
            { 
               if(this.List.Count > 9)
                   this.List.RemoveAt(0);         
               this.List.Add(customer);
            }
        }
