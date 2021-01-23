    private void button1click(object sender, EventArgs e)
    {
           Foo();
    }
    void EnterPressed(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Foo();
        }
    }
    void Foo()
    {
        //Do Something
    }
