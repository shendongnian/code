        //The first method is convert matrix to string
         private void Matrix_to_String()
                {
                    String myStr = "";
                    Int numRow, numCol;//number of rows and columns of the Matrix
                    for (int i = 0; i < numRow; i++)
                    {
                        for (int j = 0; j < numCol; j++)
                        {
        //In case you want display this string on a textbox in a form 
        //a b c d . . . .
        //e f g h . . . .
        //i j k l . . . .
        //m n o p . . . .
        //. . . . . . . . 
         
                           textbox.Text = textbox.Text + " " + Matrix[i,j];
                            if ((j == numCol-1) && (i != numRow-1))
                            {
                                textbox.Text = textbox.Text + Environment.NewLine;
                            }
                        }
                      
                    }
        myStr = textbox.text;
        myStr = myStr.Replace(" ", String.Empty);
        myStr = myStr.Replace(Environment.NewLine,String.Empty);
                }
    
    //and the second method convert string back into 2d array
    
        private void String_to_Matrix()
                {
                    int currentPosition = 0;
                    Int numRow, numCol;//number of rows and columns of the Matrix
                    string Str2 = textbox.Text;
              
                    Str2 = Str2 .Replace(" ", string.Empty);
                    Str2 = Str2 .Replace(Environment.NewLine, string.Empty);
        
                    for (int k = 0; k < numRow && currentPosition < Str2 .Length; k++)
                    {
                        for (int l = 0; l < numCol && currentPosition < Str2 .Length; l++)
                        {
                            char chr = Str2 [currentPosition];
        
                                Matrix[k, l] = chr ;                       
        
                            currentPosition++;
                        }
                    }  
                      
                }
