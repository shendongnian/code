    try
    {
     cIndex = (int)rand.Next(App.viewablePhrases.Count);
     phrase = App.viewablePhrases[cIndex];
    }
    catch(System.ArgumentOutOfRangeException e)
    {
      Console.WriteLine("Exception information: {0}", e);
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception information: {0}", e);
    }
