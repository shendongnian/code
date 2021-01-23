        public void Example()
        {
            var myCustomer = new Customer() { Name = "Erik";}
            var myImmutableCustomer = new Immutable<Customer>(myCustomer);
            myCustomer.Name = null;
            myCustomer.CreditCardNumbers = null;
            //These guys do not throw exceptions
            Console.WriteLine(myImmutableCustomer.Copy.Name.Length);
            Console.WriteLine("Credit card count: " + myImmutableCustomer.Copy.CreditCardNumbers.Count);
        }
