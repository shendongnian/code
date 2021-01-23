    void btnSave_Click(object sender, EventArgs e)
    {
       try
       {
         SaveSomething();
         Alert.Show("You document has been saved");
       }
       catch (ReadOnlyException)
       {
         Alert.Show("You do not have write permission to this file");
       }
    }
