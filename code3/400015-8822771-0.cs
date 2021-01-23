    class Member
    {
        public string Name{get;set;}
        public int ID{get;set;}
    }
    
    var members = new []
    {
       new Member(){ID = 1, Name = "John"},
       new Member(){ID = 2, Name = "Mary"}
    };
    
    m_ComboBox.DataSource = members;
    m_ComboBox.DisplayMember = "Name"
    m_ComboBox.ValueMember = "ID";
