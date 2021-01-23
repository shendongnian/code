    List<string> result = new List<string>();
          using(StreamReader content = File.OpenText("text"))
          {
            while(!content.EndOfStream)
            {
              string line = content.ReadLine();
              var substrings = line.Split(' ');
              result.Add(substrings[substrings.Length-1]);
            }
          }
