    private void Grid_TextInput(object sender, TextCompositionEventArgs e)
    {
        Char keyChar = (Char)System.Text.Encoding.ASCII.GetBytes(e.Text)[0];
        Debug.WriteLine(keyChar);
    }
