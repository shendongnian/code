    public class SimFile
    {
        public class NoteChart
        {
            public SimFile SimFile { get; internal set; }
        }
        public NoteChart CreateNoteChart()
        {
            NoteChart nc = new NoteChart();
            nc.SimFile = this;
            // Here you can add the note chart to the SimFile dictionary
            return nc;
        }
    }
