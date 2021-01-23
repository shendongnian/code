    // var fileContent = System.IO.File.ReadAllText("somefilethathasthestuff");
    var fileContent = @"Tom 1 2
    Jerry 3 4";
    var readData = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
       .Aggregate(new { names = new List<string>(), data = new List<int[]>() },
           (result, line) => {
               var fields = line.Split(new []{' '}, 2);
               result.names.Add(fields[0]);
               result.data.Add(fields[1].Split(new[] { ' ' }).Select(n => int.Parse(n)).ToArray());
               return result;
            }
       );
    string[] firstarray = readData.names.ToArray();
    int[][] secondarray = readData.data.ToArray();
