     string[] readText = File.ReadAllLines(path, Encoding.UTF8);
     string text = string.Empty; // or use StringBuilder;
     foreach (string s in readText)
     {
         text += $"\u2022 {s}" + System.Environment.NewLine;
     }
     txtBox1.Text = text;
