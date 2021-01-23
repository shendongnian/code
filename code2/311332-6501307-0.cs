    private ore b1 = null;
    private ore b2 = null;
    private List<ore> books = new List<ore>(); // create a list at class level
    public Form1()
    {
        InitializeComponent();
        b1 = new ore(); 
        b2 = new ore();
        books.Add(b1);
        books.Add(b2);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        FileStream fs = new FileStream("ore.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, books);
        fs.Close();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        FileStream fs = new FileStream("ore.dat", FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        /*use the old list don't create new one 
        and also the new one you are creating has the same
        name as the class level one which may makes conflicts to you.*/
        books = (List<ore>)bf.Deserialize(fs);
        fs.Close();
        if (books!=null)
        {
            if (books.Count > 0)
            {
                b1 = books[0];
                textBox3.Text = books[0].Titan.ToString();
            }
            if (books.Count > 1)
            {
                b2 = books[1];
                textBox4.Text = books[1].Eperton.ToString();
            }
        }
    }
