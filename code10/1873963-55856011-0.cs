    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp9
    {
        public class GameObject
        {
            public int key { get; set; }
            public string EN { get; set; }
            public string FR { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<string> EngBasicPhrases = new List<string>()
    {
        "Hello", "How are you?", "Hot",  "Thank you", "Welcome",
        "Let's go", "My name is...", "Cold", "Good luck",
        "Congratulations", "Bless you","I forgot","Sorry","I'm fine",
        "It's no problem","Don't worry","Here it is","What?","Of course",
        "Boy","Girl","Man","Woman","Friend","Almost","Late"
    
    };
                List<string> FrBasicPhrases = new List<string>()
    {
        "Salut","Ca va?","Chaud", "Merci", "Bienvenu", "Allons-y","Je m'appelle","Du froid",
        "Bonne chance","Felicitations","A vos souhaits","J'ai oublie","Desole","Je vais bien",
        "Ce n'est pas grave","Ne t'en fais pas","Voila","Comment?","Bien sur","Un garcon","Une fille",
        "Un home","Une femme","Un ami","Presque","En retard"
    };
    
                List<GameObject> list = new List<GameObject>();
                int max = EngBasicPhrases.Count;
    
                for (int i = 0; i < max; i++)
                {
                    list.Add(new GameObject { key = i, EN = EngBasicPhrases[i], FR = FrBasicPhrases[i] });
                }
    
                Random rnd = new Random();
                int nextIndex = rnd.Next(max);
    
                Console.WriteLine($"Guess this: { list[nextIndex].EN}");
                Console.WriteLine($"Youe answer is (type number, press enter):");
                for (int i = 0; i < max; i++)
                {
                    Console.WriteLine($"{list[i].key} - { list[i].FR}");
                }
                int answer = int.Parse(Console.ReadLine());
    
                if(nextIndex == answer)
                {
                    Console.WriteLine($"you won a game !");
                }
                else
                {
                    Console.WriteLine($"you lost a game ... the correct answer was {list[nextIndex].key} - {list[nextIndex].FR} ");
                }           
    
                Console.WriteLine($"");
                Console.WriteLine($"Game over");
                Console.ReadKey();
            }
        }
    }
