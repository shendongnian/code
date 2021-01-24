    private static double[] GetNotes()
    {
       var notes = new double[3];
  
       for (var i = 0; i < notes.Length; i++)
       {
          do
          {
             Console.Clear();
             Console.WriteLine("Veuillez saisir la note" + i + "\n");
          } while (!double.TryParse(Console.ReadLine(), out notes[i]));
       }
       return notes;
    }
