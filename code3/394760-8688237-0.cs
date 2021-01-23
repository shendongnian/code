    richtextBox2.SuspendLayout();
    for (int i = 0; i < split.Length; i++)
    {
      richTextBox2.Text* += split[i] + "\n";   
    }
    MessageBox.Show("Tamam!");
    richtexbox2.ResumeLayout();
