    public class Rules
    {
        private int m_timepointId = 0;
        private int m_studyId = 0;
    
        public int TimepointId
        {
            get { return m_timepointId; }
            set { m_timepointId = value;}
        }
    
        public int StudyId
        {    
            get { return m_studyId; }
            set {m_studyId = value; }
        }
    
        // New method
        public abstract void ApplyRule();
    }
    class RowRules : Rules
    {
       private int m_row;
    
       public int Row
       {
           get { return m_row; }
           set { m_row = value; }
       }
    
       public override void ApplyRule() { // Row specific implementation }
    }
    class ColumnRules : Rules
    {
        private int m_column;
    
        public int Column
        {
            get { return m_column; }
            set { m_column = value; }
        }
    
       public override void ApplyRule() { // Column specific implementation }
    }
