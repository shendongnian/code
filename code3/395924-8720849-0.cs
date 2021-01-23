    private void button3_Click(object sender, EventArgs e)
    {
        SqlCommand saveCommand = new SqlCommand(
            "INSERT INTO Receipt (DateCleared, CategoryID, Amount, Store, DateEntered, HaveReceipt) VALUES (@DateCleared, @CategoryID, @Amount, @Store, @DateEntered, @HaveReceipt)");
        // Create a parameter, set the database type, and then set the value
        saveCommand.Parameters.Add("@DateCleared", SqlDbType.DateTime);
        saveCommand.Parameters["@DateCleared"] = dateTimePicker1.Value;
        // The same
        saveCommand.Parameters.Add("@DateEntered", SqlDbType.DateTime);
        saveCommand.Parameters["@DateEntered"] = dateTimePicker2.Value;
        // I'm assuming that this is a string. I could be wrong.
        saveCommand.Parameters.Add("@ComboBox", SqlDbType.VarChar);
        saveCommand.Parameters["@ComboBox"] = (String)comboBox1.SelectedValue;
        // I dunno, is this a float? Well now it is.
        saveCommand.Parameters.Add("@Amount", SqlDbType.Float);
        saveCommand.Parameters["@Amount"] = Convert.ToDouble(textBox1.Text);
        // Seems like this should be a bool (hopefully)
        saveCommand.Parameters.Add("@HaveReceipt", SqlDbType.Bit);
        saveCommand.Parameters["@HaveReceipt"] = checkBox1.Checked);
        // I guess this is a string, but who knows
        saveCommand.Parameters.Add("@Store",  SqlDbType.VarChar);
        saveCommand.Parameters["@Store"] = textBox2.Value;
        // No idea why this is here
        this.Dispose();
    }
