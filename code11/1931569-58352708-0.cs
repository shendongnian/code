    public class Globals
    {
        public int X;
        public int Y;
    }
    var globals = new Globals { X = 1, Y = 2 };
    Console.WriteLine(await CSharpScript.EvaluateAsync<int>("X+Y", globals: globals));
