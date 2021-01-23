    class Program
        {
            string fname = string.Empty;
            string Lname = string.Empty; 
           
           static void Main(string[] args)
            {
                DemoForSerializable demo = new DemoForSerializable();
    
                Stream ms = demo.SerializeToMS(demo);
                ms.Position = 0;
    
                DemoForSerializable demo1 = new BinaryFormatter().Deserialize(ms) as DemoForSerializable;
    
                Console.WriteLine(demo1.Fname);
                Console.WriteLine(demo1.Lname);
                Console.ReadLine();
            }
          
        }
