    StreamWriter SW = File.AppendText(@"C:\Users\mac\txt.txt"); 
    SW.WriteLine(textBox1.Text); SW.WriteLine(textBox2.Text); 
    //rather use string as below code
    String textToBeWritten = ""; 
    textToBeWritten += textBox1.Text;
    textToBeWritten += "#"+textBox2.Text;   //how many textBoxes like that you want
    //finally write using
    SW.WriteLine(textToBeWritten ); 
