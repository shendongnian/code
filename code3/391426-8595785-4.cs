    List<string> cbTexts = new List<string>();
    if (CheckBox1.Checked)
       cbText.Add(CheckBox1.Text);
    if (CheckBox2.Checked)
       cbText.Add(CheckBox2.Text);
    if (CheckBox3.Checked)
       cbText.Add(CheckBox3.Text);
    if (CheckBox4.Checked)
       cbText.Add(CheckBox4.Text);
    string ClientString = String.Empty;
    
    foreach (string cbText in cbTexts)
    {
      ClientString += cbText ", ";
    }
    
    ClientString.Remove(ClientString.Length - 2); // remove trailing comma
