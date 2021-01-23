    public class ImportedFile
    {
        private List<FileLine> lines;
        public List<FileLine> Lines
        {
            get { return new ReadOnlyCollection(lines); }
        }
        public void AddLine(FileLine fl)
        {
            this.lines.Add(fl);
        }
        public void RemoveLine(FileLine fl)
        {
            this.lines.Remove(fl);
        }
        //Instance methods for comparing lines within the same file
        //Static methods for comparing Files
    }
    public class FileLine
    {
        private String labelA;
        public String LabelA
        {
          get { return labelA; }
          set { labelA = value; }
        }
        private String labelB;
        public String LabelB
        {
          get { return labelB; }
          set { labelB = value; }
        }
    }
