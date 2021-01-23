    abstract class Token
    {
        public abstract void DoStuff();
    }
    
    class KeywordToken : Token
    {
        List<string> Synonyms { get; set; }
        public override void DoStuff()
        {
            foreach (string s in Synonyms)
            {
                Console.WriteLine(s);
            }
        }
    }
    
    class GameObjectToken : Token
    {
        public override void DoStuff()
        {
            // Do something else.
        }
    }
    // Elsewhere
    foreach (var token in cmd.Toks)
    {
        token.DoStuff();
    }
