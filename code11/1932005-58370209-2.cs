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
                if (Item != null)
                {
                    Item.Status = value;
                }
            }
        }
        Item Item { get; set; }
        Hand(int id)
        {
            Id=id;
            Status=false;
        }
    }
    class Item
    {
        public int Id;
        public bool Status;
        public Item(int id)
        {
            Id=id;
            Status=false;
        }
    }
    class Pen : Item
    {
        public Pen(int id)
            : base(id)
        {
        }
    }
    class Eraser : Item
    {
        Eraser(int id)
            : base(id)
        {
        }
    }
    class Pencil : Item
    {
        public Pencil(int id)
            : base(id)
        {
        }
    }
