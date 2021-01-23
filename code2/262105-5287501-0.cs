    for (int i = 0; i < sortedList.Count; i++)
    {
       if (i % 3 == 0)
       {
           Console.Write("|"); // write beginning of the row
       }
       Console.Write(sortedList[i].ToString().PadRight(10)); // write cell
       Console.Write("|"); // write cell divider
       if (i % 3 == 2)
       {
          Console.WriteLine() // write end of the row       
       }
    }
    // optional: write empty cells if sortedList.Count % 3 != 0
    // optional: write end of the row if sortedList.Count % 3 != 2
