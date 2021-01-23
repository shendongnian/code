       TextReader tr = new System.IO.StreamReader("My5MegFile.txt");
       string line;
       while((line = tr.ReadLine()) != null)
       {
           line = line.Replace("oldvalue", "newvalue");
           Console.WriteLine(line);        
       }
       // close reader etc...
