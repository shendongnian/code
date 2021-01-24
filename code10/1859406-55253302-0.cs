    private void btnReadRandomNumbers_Click(object sender, EventArgs e)
    {
        StreamReader inputFile;
        try
        {
        int number = 0;
        int count = 0;
        int sum = 0;
        lstRandomNumbers.Items.Clear();
        if (fodOpenFile.ShowDialog() == DialogResult.OK)
        {
            inputFile = File.OpenText(fodOpenFile.FileName);
            lstRandomNumbers.Items.Clear();
            while (!inputFile.EndOfStream)
            {
                number = int.Parse(inputFile.ReadLine());
                count = count + 1;
                lstRandomNumbers.Items.Add(number);
            }
            
            //Add this loop
            
            for (int i = 0; i < lblSumNumbers.Items.Count; i++)
            {
                sum+= Int32.Parse(lblSumNumbers.Items[i].ToString());
            }
            //End
            lblNumberCount.Text = count.ToString();
            lblSumNumbers.Text = sum.ToString(); //change `number' to `sum`
        }
        }
        catch (Exception ex)
        {
        MessageBox.Show("There is a problem with the disk file." + Environment.NewLine + ex.Message, "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
