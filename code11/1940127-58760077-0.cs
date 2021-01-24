    using System;
    namespace FirstConsoleProgram
    {
        public class Game { } //Currently Nothing
        public class Story : Game
        {
            public int stro;
            private string intro;
            public Story(int _stro)
            {
                stro = _stro;
                if (stro == 1)
                {
                    SetIntroTXT("how you \"The Avatar\" have to save the world from pain and destruction. \n You travel the world gaining new spells and abilities until the ultimate battle \n where you have to fight Lord Ozai");
                    bool reply = story_Confirmation();
                    Console.WriteLine(reply);
                }
            }
            void FirstStory()
            {
                ; //Currently Nothing
            }
            void SetIntroTXT(string txt)
            {
                intro = txt;
            }
            bool story_Confirmation()
            {
                Console.Clear();
                Console.WriteLine(intro);
                Console.WriteLine();
                string awn;
                int cont;
                do
                {
                    Console.WriteLine("Are you sure you want to confirm? (y/n)");
                    awn = Console.ReadLine().ToUpper();
                    cont = -1;
                    if (awn == "YES" || awn == "Y")
                    {
                        cont = 1;
                    }
                    else if (awn == "NO" || awn == "N")
                    {
                        cont = 2;
                    }
                    else
                    {
                        Console.WriteLine("That is not an acceptable answer, Please try again...");
                    }
                } while (cont == -1);
                return cont == 1;
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Welcome to Choose your adventure!");
                Console.WriteLine();
                Console.WriteLine("Out of the 5 Stories, which one would you like to play?");
                string stro_sel = Console.ReadLine();
                Story GameStory = new Story(1);
            }
        }
    }
