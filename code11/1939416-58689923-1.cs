    StreamReader sr = new StreamReader(@"c:\test.txt" , Encoding.UTF8); 
    int richTextBoxCursor = 0;
    while (!sr.EndOfStream){
       
       richTextBoxCursor = richTextBox.TextLength;
       string line = sr.ReadLine();
       line = line.Replace(Convert.ToChar(0x0).ToString(), "NUL");
       richTextBox.AppendText(line);
       i = 0;
       while(true){
         i = line.IndexOf("NUL", i) ;
         if(i == -1) break;
         // This specific select function select text start from a certain start index to certain specified character range passed as second parameter
         // i is the start index of each found "NUL" word in our read line
         // 3 is the character range because "NUL" word has three characters
         richTextBox.Select(richTextBoxCursor + i , 3);
         richTextBox.SelectionColor = Color.White;
         richTextBox.SelectionBackColor = Color.Black;
         i++;
       }
         
    }
