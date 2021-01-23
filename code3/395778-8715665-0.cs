    StreamReader sr = new StreamReader(dlg.FileName);
    String ganzes = sr.ReadToEnd();
    String[] allezeilen = ganzes.Split('\n');
    foreach (string CurrentLine in allezeilen)
      {
         string[] ssa = CurrentLine.Split('\t');
         for (CurrentRowIndex=0, CurrentRowIndex<ssa.Count, CurrentRowIndex++)
             {
               if ssa[CurrentRowIndex].Contains("Verwendungszweck")
                       verwendungszw =ssa[++CurrentRowIndex] ; // or add it to a list and maybe exit for 
             }
      }
