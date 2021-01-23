    if( !(keyData >= Keys.F1 && keyData <= Keys.F12))
    {
        char key = (char)keyData;
        if(char.IsLetterOrDigit(key))
        {
            Console.WriteLine(key);
            return false;
        }
               
    }
    return base.ProcessCmdKey(ref msg, keyData);
