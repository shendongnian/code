    string optional = "with a clause I don't want" 
    // displays "I have a sentence"
    string foo = "I have a sentence with a clause I don't want.";
    int idxFoo = foo.IndexOf(optional);
    Console.WriteLine(idxFoo < 0 ? foo : foo.Remove(idxFoo));
    // displays "I have a sentence and I like it."
    string bar = "I have a sentence and I like it.";
    int idxBar = bar.IndexOf(optional);
    Console.WriteLine(idxBar < 0 ? bar : bar.Remove(idxBar));
