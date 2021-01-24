    List<string> lines = new List<string>(textBox1.Lines);
    
    for(int i = 0; i < lines.Count; i++) 
    {
       if (lines[i].Contains("click()")) 
       {
          lines.Insert(i + 1, "sleep(5)");
          i += 2;
       }                
    }
    textBox1.Lines = lines.ToArray();
