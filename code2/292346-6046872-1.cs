     var parts = lstboxColumnList.Items.OfType<ListItem>().Select(i => new { 
                              Part1 = i.Text.Split(' ').FirstOrDefault(),
                              Part2 = i.Text.Substring(i.Text.IndexOf(' '))
                           });
     foreach (var part in parts)
     {
         var p1 = part.Part1;
         var p2 = part.Part2;
         // TODO, use p1, p2 in magic code!!
     }
