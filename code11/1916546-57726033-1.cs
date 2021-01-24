    for (int i = 0; i < scrapedWikiWords.Capacity; i++) 
    {
       processWikiWord(....);
    
       if (i % 50 == 0)
       {   // Update the user after 50, 100, 150, 200... words.
           // (Updating after every single word would be way too much output!)
           Console.WriteLine(i);
       }
    }
