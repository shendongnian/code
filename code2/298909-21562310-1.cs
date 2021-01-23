    using System;
    using System.Collections.Generic;
    using com.blogspot.jeanjmichel.jsontest.model;
    namespace com.blogspot.jeanjmichel.jsontest.main
    {
        public class Program
        {
            static void Main(string[] args)
            {
                List<Address> addresses = new List<Address>();
                addresses.Add(new Address(1, "Rua Dr. Fernandes Coelho, 85", "15º andar", "São Paulo", "São Paulo", "Brazil", "05423040"));
                addresses.Add(new Address(2, "Avenida Senador Teotônio Vilela, 241", null, "São Paulo", "São Paulo", "Brazil", null));
                
                Contact contact = new Contact(1, "Ayrton Senna", addresses);
                
                Console.WriteLine(contact.ToJSONRepresentation());
                Console.ReadKey();
            }
        }
    }
