    var dog = animal as Dog; if (dog != null)
    {
        Console.WriteLine("Parent Dog Name = " + dog.name);
        var purebred = dog.Puppy as Purebred; if (purebred != null)
        {
             Console.WriteLine("Purebred Puppy Name = " + purebred.Name);
        }
        var mutt = dog.Puppy as Mongrel; if (mutt != null)
        {
             Console.WriteLine("Mongrel Puppy Name = " + mutt.Name);
        }
     }
        
