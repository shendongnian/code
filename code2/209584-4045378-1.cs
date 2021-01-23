    Control foo = null;
    Control bar = new Control();
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        test();
        test();
        Page.Controls.Add(foo);
    }
    void test()
    {
        i++;
        bar.Controls.Clear()
        bar.Controls.Add(new LiteralControl(i.ToString()));
        if (foo == null)
        {
            foo = new Control();
            foo.Controls.Add(bar);
        }
    }
