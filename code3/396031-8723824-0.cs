    class ArithmeticExpressionParser<T> : Parser where T : IConvertible
    {
        T num1, num2;
    
        /* ......... */
    
        void ParseNumber()
        {
            string temp = String.Empty;
    
            while (char.IsDigit(PeekNextToken()))
            {
                GetNextToken();
                temp += Token;
            }
    
            //num1 = T.Parse(temp);  // <<< the problem
            num1 = (T)Convert.ChangeType( temp, typeof( T ) );
        }
    }
