    // Assuming you have entered a number in a textbox
    string[] User = { "XYZ", "ABC", "DEF" }; 
    string[] Number = { "1234567890", "2345678901", "345678901" }; 
    foreach(string s in Number)
    {
    if(s == textBox1.Text)
    {
    MessageBox.Show(User[s]);
    }
    }
