      string path = "C:\\Users\\user\\Desktop\\test.txt";
  
      // sorted scores
	  var sortedPlayersByScores = File.ReadAllLines(path)
                                      .Select(line => line.Split(' '))
                                      .Select(elem => new 
                                       Tuple<string, int>(elem[0], int.Parse(elem[1])))
                                      .OrderBy(x => x.Item2);
      
      // sorted players by name
      var sortedPlayersByName = File.ReadAllLines(path)
                                    .Select(line => line.Split(' '))
                                    .Select(elem => new 
                                     Tuple<string, int>(elem[0], int.Parse(elem[1])))
                                    .OrderBy(x => x.Item1);
