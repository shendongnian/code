    var sample = Console.ReadLine();
    var letterCounter = sample.Where(char.IsLetterOrDigit)
                        .GroupBy(char.ToLower)
                        .Select(counter => new { Letter = counter.Key, Counter = counter.Count() })
                        .Where(c=>c.Counter>1);
    foreach (var counter in letterCounter){
        Console.WriteLine(String.Format("{0} = {1}", counter.Letter,counter.Counter));
    }
