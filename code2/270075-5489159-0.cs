    SpeechRecognizer rec = new SpeechRecognizer();
    Choices c = new Choices();
    c.Add("one");
    c.Add("two");
    c.Add("three");
    var gb = new GrammarBuilder(c);
    var g = new Grammar(gb);
    rec.LoadGrammar(g);
