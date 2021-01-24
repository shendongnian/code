     val = Console
       .ReadLine()
       .Trim()
       .ToUpper();
     val = val.Substring(0, Math.Max(1, val.Length));
     switch (val) {
       case "L":
         // We read valid integer, turn it to string and out to Temp
         Temp.Add(ReadInteger("add temperature : ").ToString());
         Console.Clear();
         break;
       case "T":
         int deleteIndex = ReadInteger(
           "$"Which temp do you want to delete [index from 1 to {Temp.Count}]: ");
         if (deleteIndex >= 0 && deleteIndex < Temp.Count)
           Temp.RemoveAt(deleteIndex);
         else
           Console.WriteLine("Index out of range");
         break;
      ...   
     }
