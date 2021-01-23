     var parts = lstboxColumnList.Items.ToList().Select(i => new { 
                              Part1 = i.Text.Split(' ').FirstOrDefault(),
                              Part2 = i.Test.Remove(Part1.length)
                           });
     foreach (var part in parts)
     {
         var p1 = part.Part1;
         var p2 = part.Part2;
         // TODO, use p1, p2 in magic code!!
     }
