    private class NickName
    {
        public string Nick { get; set; }
        public int Value { get; set; }
    }
    private BindingSource source = null;
    private List<NickName> NickNames = null;
    private void Form1_Load(object sender, EventArgs e)
    {
        NickNames = new List<NickName>();
        NickNames.AddRange(new[] {
            new NickName() { Nick = "", Value = 0 },
            new NickName() { Nick = "Andrea", Value = 10 },
            new NickName() { Nick = "Arnold", Value = 20 },
            new NickName() { Nick = "Barbara", Value = 30 },
            new NickName() { Nick = "Billy", Value = 40 },
            new NickName() { Nick = "Clint", Value = 50 },
            new NickName() { Nick = "Cindy", Value = 60 },
        });
        source = new BindingSource();
        source.DataSource = NickNames;
        txtAutoComp.AutoCompleteMode = AutoCompleteMode.Suggest;
        txtAutoComp.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtAutoComp.AutoCompleteCustomSource.AddRange(NickNames.Select(n => n.Nick).ToArray());
        Binding textBind = new Binding("Text", source, "Nick", true, DataSourceUpdateMode.OnPropertyChanged);
        textBind.Parse += (s, evt) => {
            source.CurrencyManager.Position = NickNames.FindIndex(1, r => r.Nick.Equals(evt.Value));
        };
        txtAutoComp.DataBindings.Add(textBind);
        lblNickName.DataBindings.Add(new Binding("Text", source, "Nick"));
        lblNickValue.DataBindings.Add(new Binding("Text", source, "Value"));
    }
    private void btnFindNick_Click(object sender, EventArgs e)
    {
        FindNick(txtAutoComp.Text);
    }
    private void txtAutoComp_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) {
            e.SuppressKeyPress = true;
            FindNick(txtAutoComp.Text);
        }
    }
    void FindNick(string partialName) 
        => this.source.CurrencyManager.Position = NickNames.FindIndex(
            1, r => r.Nick.Contains(partialName)
        );
