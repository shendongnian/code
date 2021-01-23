    List<ore> books = new List<ore>(); // create list
    private void button2_Click(object sender, EventArgs e)
    {
        FileStream fs = new FileStream("ore.dat", FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        List<ore> books = (List<ore>)bf.Deserialize(fs);
        fs.Close();
        if (books != null)
        {
            if (books.Count > 0)
                textBox3.Text = books[0].SomeProperty.ToString();//update the 3rd text box
            if (books.Count > 1)
                textBox4.Text = books[1].SomeProperty.ToString();//update the 4th text box
        }
    }
