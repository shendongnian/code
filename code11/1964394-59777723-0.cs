    class Program
        {
            static void Main(string[] args)
            {
                List<Kikker> kikkers2Kikkers = new List<Kikker>();
    
                Kikker Kikker1 = new Kikker("Frank", "Man", 2);
                Kikker Kikker2 = new Kikker("John", "Man", 1);
    
                Ooievaar ooievaar1 = new Ooievaar("Britt", "vrouw", 2, 50);
    
                //add the kikkers to the list
                kikkers2Kikkers.Add(Kikker1);
                kikkers2Kikkers.Add(Kikker2);
    
                //random number
                Random rnd = new Random();
                var rndNumber = rnd.Next(0, 2);
                Console.WriteLine(rndNumber); 
    
                //calling Eatkikker
                string deadKikker = ooievaar1.EetKikker(kikkers2Kikkers, rndNumber);
    
                //Rip kikker
                Console.WriteLine("Byebye " + kikkers2Kikkers.ElementAt(rndNumber));
    
                //remove dead kikker from list
                kikkers2Kikkers.RemoveAt(rndNumber);
    
                Console.ReadKey();
            }
        }
