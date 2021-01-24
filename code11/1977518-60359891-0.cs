    private void mainMethod() 
    {
        string result = testNumbers("9512636272,9518263729,1111111117");
        MessageBox.Show(result);
    }
    private string testNumbers(string mob)
    {
        string[] MobileNumber = mob.Split(new Char[] { ',' });
        List<string> incorrect = new List<string>();
        StringBuilder operatorResultBuilder = new StringBuilder();
        List<string> correct = new List<string>();
        foreach (string number in MobileNumber)
        {
            if (validNumber(number))
            {
                correct.Add(number);
                operatorResultBuilder.Append(number + " = valid,");
            }
            else
            {
                string buffer = number;
                if (buffer == null)
                    buffer = "";
                incorrect.Add(buffer);
                operatorResultBuilder.Append((buffer) + " = invalid,");
            }
        }
        
        string operatorResult = correct.Count.ToString() + " Correct : " +        
            Incorrect.Count.ToString() + " Incorrect: " +             
            operatorResultBuilder.ToString();
        
        if (operatorResult.EndsWith("<"))
            operatorResult = operatorResult.Substring(0, operatorResult.Length - 1);
        return operatorResult;
    }
    private bool validNumber(string number)
    {
        if (number == null || number.Length != 10)
            return false;
        foreach (char c in number)
        {
            if (!Char.IsDigit(c))
                return false;
        }
        return true;
    }
