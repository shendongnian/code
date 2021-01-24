     using System.Linq;
     ...
     private void updateRatingLabels() {
       var tops = AllNames()
         .OrderBy(pair => pair.Value)                      // less seconds - better rank
         .ThenBy(pair => pair.Key, StringComparer.Ordinal) // On tie, use names
         .Take(5)                                          // Top 5 or less  
         .ToArray();
       // Clear all the labels
       for (int i = 18; i <= 22; ++i)
         Controls.Find($"label{i}", true).First().Text = "";
       for (int i = 28; i <= 32; ++i)
         Controls.Find($"label{i}", true).First().Text = "";
       // Put best results
       for (int i = 0; i < tops.Length; ++i) {
         Controls.Find($"label{i + 18}", true).First().Text = tops[i].Key;
         Controls.Find($"label{i + 28}", true).First().Text = tops[i].Value.ToString();
       }
     }
