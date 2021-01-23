    Font fnt=new Font("Verdana", 8F, FontStyle.Italic, GraphicsUnit.Point);
    if (richTextBox2.Find(mystring)>0)
    {
        int my1stPosition=richTextBox1.Find(strSearch);
        richTextBox2.SelectionStart=my1stPosition;
        richTextBox2.SelectionLength=strSearch.Length;
        richTextBox2.SelectionFont=fnt;
        richTextBox2.SelectionColor=Color.CadetBlue;
    } 
