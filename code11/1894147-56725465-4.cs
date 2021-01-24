    public void Form_Load(object sender, EventArgs e)
    {
        selectedValueSubject = new List<int>();
        bsSelected.DataSource = new List<TitleData>();
        lbSelectedSubject.DisplayMember = "Title";
        lbSelectedSubject.ValueMember = "Id";
        lbSelectedSubject.DataSource = bsSelected; // <= this is a BindingSource at the class level
        .....
    
    }
