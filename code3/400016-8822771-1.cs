    class Member
    {
        public string Name{get;set;}
        public string Address{get;set;}
        public int ID{get;set;}
        public string Description
        {
            get
            {
                return string.Format("{0}, {1}", Name, Address);
            }
        }
    }
    
    var members = new []
    {
       new Member(){ID = 1, Name = "John"},
       new Member(){ID = 2, Name = "Mary"}
    };
    
    m_ComboBox.DataSource = members;
    m_ComboBox.DisplayMember = "Description"
    m_ComboBox.ValueMember = "ID";
