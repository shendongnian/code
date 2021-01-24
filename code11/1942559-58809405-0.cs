    static void Main(string[] args)
    {
        // You need to create instance this class once
        // earlier you were creating it every time the loop started
        // so your values were reset to default
        var app = new Buildings();
        var answer = "yes";
        while (answer != "exit")
        {
            Console.WriteLine("Start loop");
            answer = Console.ReadLine();
            if (answer == "a")
            {
                app.Clicker();
            }
            else if (answer == "b")
            {
                app.ManorUpgrader();
            }
            Console.ReadKey();
        }
    }
