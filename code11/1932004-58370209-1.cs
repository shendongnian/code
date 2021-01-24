    class Hand
    {
        public int Id;
        private bool m_Status;
        public bool Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
                if (Pen != null)
                {
                    Pen.Status = value;
                }
            }
        }
        Pen Pen { get; set; }
        Hand(int id)
        {
            Id=1;
            Status=false;
        }
    }
    class Pen
    {
        public int Id;
        public bool Status;
        Pen(int id)
        {
            Id=1;
            Status=false;
        }
    }
