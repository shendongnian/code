    private static void GetAnswer(string clipboardText)
    {
        //Loop through all questions and answers//
        foreach (question q in questionList)
        {
            //If we have found an answer that is exactly the same show an Notification//
    
            //Startwith zoekt naar alle vragen die matchen vanaf het begin van de zin en Endwith alle vragen die matchen vanaf het eind van de zin//
            if (q._question.StartsWith(clipboardText) || q._question.EndsWith(clipboardText))
            {
                ShowNotification(q._question, q._answer);
                break;
            }
        }
    
        var parts = clipboardText.Replace(" ", "");
        var isValid = true;
        Double a, b;
    
        // Make sure it's format A # B
    
        char? op = null;
        int end;
        var validOperators = new char[] { '+', '-', ':', 'x', '%' };
        // find operator 
        foreach (char oper in validOperators)
        {
            if (parts.Contains(oper))
            {
                end = parts.IndexOf(oper);
                op = oper;
            }
        }
        if (!op.HasValue)
            return;
        // split to argument with op
        var arguments = parts.Split(op.Value);
    
    
        // Parse first number
        isValid = Double.TryParse(arguments[0], out a);
        if (!isValid)
            return;
    
    
    
    
        // Parse 2nd number
        isValid = Double.TryParse(arguments[1], out b);
        if (!isValid)
            return;
    
        // Now calculate the answer
        string answer = null;
        switch (op)
        {
            case '+':
                answer = (a + b).ToString();
                break;
            case '-':
                answer = (a - b).ToString();
                break;
            case ':':
                if (b == 0)
                    answer = "NaN";
                else
                    answer = (a / b).ToString();
                break;
            case 'x':
                answer = (a * b).ToString();
                break;
            // rekent percentage van een bedrag 
            case '%':
                answer = (a / b * 100).ToString();
                break;
            default:
                throw new InvalidOperationException();
        }
    
        // Show the answer
        ShowNotification(clipboardText,answer);
    }
