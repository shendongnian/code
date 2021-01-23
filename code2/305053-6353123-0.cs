    public Form1()
    {
        this.Activated += new EventHandler(Form1_Activated);
    }
    void Form1_Activated(object sender, EventArgs e)
    {
        Console.WriteLine("Activated");
    }
