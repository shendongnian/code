    foreach (TextBox box in this.Controls.OfType<TextBox>()
           .Where(tb => tb.Name.StartsWith("tbwin")))
    {
        int result;
        if(!int.TryParse(box.Text, out result))
        {
             //Not OK. Inform user
             MessageBox.Show("You need to write a valid number in " + box.Name);
        } 
    }
