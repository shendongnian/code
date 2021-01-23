    using MMLib.RapidPrototyping.Generators;
    public void Example()
    {
       WordGenerator generator = new WordGenerator();
       var randomWord = generator.Next();
       Console.WriteLine(randomWord);
       LoremIpsumGenerator loremIpsumGenerator = new LoremIpsumGenerator();
       var text = loremIpsumGenerator.Next(3,3);
       Console.WriteLine(text);
    } 
