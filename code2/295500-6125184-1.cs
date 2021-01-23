    namespace homeworkchap8
    {
        class main
        {    
            static void Main(string[] args)
            {    
                SteelClubs myClub = new SteelClubs();
                Console.WriteLine("How far to the hole?");
                myClub.mydistance = Console.ReadLine();
                Console.WriteLine("what club are you going to hit?");
                myClub.myclub = Console.ReadLine();
                myClub.SwingClub();
    
                SteelClubs mycleanclub = new SteelClubs();
                Console.WriteLine("\nDid you clean your club after?");
                mycleanclub.mycleanclub = Console.ReadLine();
                mycleanclub.clean();
    
                SteelClubs myScoreonHole = new SteelClubs();
                Console.WriteLine("\nWhat hole are you on?");
                myScoreonHole.myhole = Console.ReadLine();
                Console.WriteLine("What did you score on the hole?");
                myScoreonHole.myscore = Console.ReadLine();
                Console.WriteLine("What is the par of the hole?");
                myScoreonHole.parhole = Console.ReadLine();
    
                myScoreonHole.score();
    
                Console.ReadKey();    
            }
        }
    }
