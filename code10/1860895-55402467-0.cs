    using System;
    using System.Threading;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string nachricht = "";
                double AndereTätigkeitBeweis = 0;
            Thread NachrichtenEinleser = new Thread(()=> {
                Console.Write("Gib diene zu sendende Nachricht ein: ");//Type in the message you'd like to send
                nachricht = Console.ReadLine();//Read the user Input without stopping the actual code because it's another process
            });
            NachrichtenEinleser.Start();
            //do somewhat activity until you get a user input
            while (nachricht == ""){
                AndereTätigkeitBeweis++;
            }
            //Write out the user input
            Console.WriteLine($"User Input: {nachricht}|AndereTätigkeitBeweis: {AndereTätigkeitBeweis}");
            Console.ReadLine();
        }
    }
