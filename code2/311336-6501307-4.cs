    [Serializable]
    public class ore
    {
        public float Cost;
    }
    private List<ore> books = new List<ore>(); // create a list at class level
    public Form1()
    {
        InitializeComponent();
        books.Add(new ore());
        books.Add(new ore());
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // 1st text box input is float
        float tempFloat;
        if (float.TryParse(textBox1.Text, out tempFloat))
        {
            books[0].Cost = tempFloat;
        }
        else
            MessageBox.Show("uh oh");
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        // 2nd text box input is float
        float tempFloat;
        if (float.TryParse(textBox2.Text, out tempFloat))
        {
            books[1].Cost = tempFloat;
        }
        else
            MessageBox.Show("uh oh");
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
                //we don't need d1, d2 any more
                //b1 = books[0];
                textBox3.Text = books[0].Cost.ToString();
            }
            if (books.Count > 1)
            {
                //we don't need d1, d2 any more
                //b2 = books[1];
                textBox4.Text = books[1].Cost.ToString();
            }
        }
    }
