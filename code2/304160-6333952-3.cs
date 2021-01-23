    private void button2_Click(object sender, RoutedEventArgs e)
    {
        foreach (String filename in listBox1.Items)
        {
            try {
                listBox2.Items.Add(Functions.HashFunction(filename));
            }
            catch (Exception ex) {
                MessageBox.Show(e.Message);
            }
        }
    }
