      var groupedByTopic = from question in forumData 
                           group question by question.Topic;
      foreach (var group in groupedByTopic)
      {
        Console.WriteLine(group.Key);
        foreach (var question in group)
        {
          Console.WriteLine("\t" + question.Name);
        }
      }
