    void Button_Click(object sender, EventArgs e)
    { 
        if (textBox1.Text == "" || textBox1.Text == "Prémio em €")
            return;
        int numMatches = 0;
        foreach (var item in listBox1.Items)
        {
          // Convert it to string to avoid object reference comparison. Not 100% 
          // sure if this is needed
          string value = item.ToString();
          if (listBox2.Items.Contains(value))
              numMatches++;
        }
        // numMatches will now contain the number of elements in the left 
        // listbox that also exist in the right listbox
        if (numMatches > 2)
        {
            double premio = Double.Parse(textBox1.Text);
            double prize = 0;
            if (numMatches == 5)
              prize = premio * 1.0;
            if (numMatches == 4)
              prize = premio * 0.75;
            else 
              prize = premio * 0.5;
            // Use string.Format() instead to get fancier formatting of numbers
            Messagebox.Show ("Sweet, you got " + numMatches + " out of 5 correct numbers. Your prize is " + prize + "€");
        }
        else
        {
            MessageBox.Show("Sorry, not enough matches - you win nothing!");
        }
    }
