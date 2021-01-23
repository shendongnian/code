    public class SimFile
    {
        public void AddNoteChart(NoteChart nc)
        {
            // Here you can add the note chart to the SimFile dictionary
        }
    }
    public class NoteChart
    {
        public SimFile PapaSimFile { get; private set; }
        NoteChart(SimFile simFile)
        {
            if (simFile == null)
            {
                // throw exception here
            }
            PapaSimFile = simFile;
            PapaSimFile.AddNoteChart(this);
        }
    }    
