    private void btnReadRandomNumbers_Click(object sender, EventArgs e)
    {
        StreamReader inputFile;
        try
        {
        int number = 0;
        int count = 0;
        int sum = 0;
        //lstRandomNumbers.Items.Clear(); //don't need this
        if (fodOpenFile.ShowDialog() == DialogResult.OK)
        {
            inputFile = File.OpenText(fodOpenFile.FileName);
            //lstRandomNumbers.Items.Clear();//don't need this
            while (!inputFile.EndOfStream)
            {
                number = int.Parse(inputFile.ReadLine());
                count = count + 1;
                //lstRandomNumbers.Items.Add(number);//don't need this
                sum+=number; // add this
            }
            lblNumberCount.Text = count.ToString();
            lblSumNumbers.Text = sum.ToString(); //change `number' to `sum`
        }
        }
        catch (Exception ex)
        {
        MessageBox.Show("There is a problem with the disk file." + Environment.NewLine + ex.Message, "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
