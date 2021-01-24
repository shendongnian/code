    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
           static void Main(string[] args)
           {            
              Player player = new Player
              {
                Name = "name coming from your input class"
              };
              UserInterface userInterface = new UserInterface(player);
            }        
       }
       class UserInterface
       {
         public UserInterface(Player player)
         {
            Console.SetWindowSize(220, 55);
            Console.WriteLine("Name: {0}", player.Name);
         }
       }
       class Player
       {
         public string Name { get; set; }
       }
    }
