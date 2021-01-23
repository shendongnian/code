    public ColdDrink(OrderTakingMenu ordertakingmenuIn)
    {
        InitializeComponent();
        this.Location = new System.Drawing.Point(5, 100);
        ordertakingmenu = ordertakingmenuIn;
        coldDrinksPanel.Visible = true;
        hotDrinksPanel.Visible = false;
    }
    private void btnHotDrinks_Click(object sender, EventArgs e)
    {
        hotDrinksPanel.Visible = true;
        coldDrinksPanel.Visible = false;
    }
