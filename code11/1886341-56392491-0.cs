     private void updateLabels() {
       var tops = AllNames()
         .OrderBy(pair => pair.Value)                      // less seconds - better rank
         .ThenBy(pair => pair.Key, StringComparer.Ordinal) // On tie, use names
         .Take(5)                                          // Top 5 or less  
         .ToArray();
       // Clear all the labels
       for (int i = 1; i <= 10; ++i)
         Controls.Find($"label{i}", true).Text = "";
       // Put best results
       for (int i = 0; i < tops.Length; ++i) {
         Controls.Find($"label{i + 1}", true).Text = tops[i].Key;
         Controls.Find($"label{i + 6}", true).Text = tops[i].Value.ToString();
       }
     }
