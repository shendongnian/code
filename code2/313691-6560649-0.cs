    namespace eheeeeeeeeeeeee
    {
        class Program
        {
            static void Main(string[] args)
            {
                Player[] players=new Player[10];
                for (int i = 0; i < 10; i++)
                {
                    string tempName;
                    int tempScore;
                    
                    Console.Write("Please enter your initials:");
                    tempName = Convert.ToString(Console.ReadLine());
    
                    Console.Write("Please enter your score:");
                    tempScore = Convert.ToInt32(Console.ReadLine());
                    
                    players[i]=new Player(tempName,tempScore);
                    
                }
    
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(players[i].ToString());
                }
                Console.ReadLine();
            }
        }
    
    
        public class Player
        {
    
            public string initials { get; set; }
    
            public int score { get; set; }
    
            public Player(string pInitials, int pScore)
            {
                initials = pInitials;
                score = pScore;
    
            }
    
            public override string ToString()
            {
                return string.Format("{0}, {1}", score, initials);
            }
        }
    }
