    string match = strings.FirstOrDefault(c=>c.ToUpperInvariant() == navn.ToUpperInvariant());
    if (match != null)
    {
       Console.WriteLine("going inside");
       strings.Remove(match);
       listBox_varer.Items.Clear();
       for (int i = 0; i <= (strings.Count - 1); i++)
       {
           string pr = string.Concat(strings[i], Environment.NewLine);
           listBox_varer.Items.Add(pr);
        }
     }
     else
     {
        Console.WriteLine("going in else");
     }
