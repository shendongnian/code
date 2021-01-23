        public class Simba : Lion
        {
        
            public Simba(string name) : base(name)
            {
               
            }
        
            public override void talk()
            {
        
                Console.WriteLine("HRRRR I'm a {0}  and this is my daughter:{1} {2}", 
                new Simba("Simba").Name, 
                new Kiara("Kiara").Name, 
                new Simba("Simba").Yahoo);
            }
        
        
            public Simba() { }
        
        }
