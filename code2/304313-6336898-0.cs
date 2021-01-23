        for (int i = 0; i <strText.Length; i++)
        {
           
           if(strText[i] == 'g')
           {
             LetterCount++;
           }
        }
        textBox1.Text = "g appears " + LetterCount + " times";
