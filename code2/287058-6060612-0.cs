    var token = request.TokenFormat;
    var matches = tokenExpression.Matches(request.TokenFormat);
    foreach (Match match in matches)
    {
        var value = match.Value;
        var tokenCode = (Token)Convert.ToInt32(value.Substring(1, (value.Contains(":") ? value.IndexOf(":") : value.IndexOf("}")) - 1));
        object data = null;
        switch (tokenCode)
        {
            case Token.AccountMask:
                data = accountMask;
                break;
            case Token.AccountLast4:
                data = accountMask.Substring(accountMask.Length - 4);
                break;
            case Token.AccountFirstDigit:
                string firstLetter = accountMask.Substring(0, 1);
                switch (firstLetter.ToUpper())
                {
                    case "A":
                        data = 3;
                        break;
                    case "V":
                        data = 4;
                        break;
                    case "M":
                        data = 5;
                        break;
                    case "D":
                        data = 6;
                        break;
                }
                break;
            case Token.AccountFirstLetter:
                data = accountMask.Substring(0, 1);
                break;
            case Token.ItemNumber:
                if(item != null)
                    data = item.PaymentId;
                break;
            case Token.Amount:
                if (item != null)
                    data = item.Amount;
                break;
            case Token.PaymentMethodId:
                if (paymentMethod != null)
                    data = paymentMethod.PaymentMethodId;
                break;
        }
        if (formatExpression.IsMatch(value))
        {
            Match formatMatch = formatExpression.Match(value);
            string format = formatMatch.Value.Replace("[", "{").Replace("]", "}");
            token = token.Replace(value, String.Format(format, data));
        }
        else
        {
            token = token.Replace(value, String.Format("{0}", data));
        }
    }
    return token;
