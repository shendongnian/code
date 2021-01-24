Func<String> ToPrint = ()=> " "; // // this is func, evaluation is deffered to invocation
  While(Current.Type != TokenType.RParen) { // ')'
     if(Current.Type == TokenType.Plus)
        Index++;
     if(Current.Type == TokenType.PrintString) {
        var ToAdd = Current.Value;
        var currentValue = ToPrint; // you cannot use ToPrint in the clausure :(
        ToPrint = () => currentValue() + Convert.ToString(ToAdd);
     }
     if(Current.Type == TokenType.String) {
        var ToAddSymbol = Current.Symbol; 
        //GetVar = object that returns the value if the dictionary contains it
        var currentValue = ToPrint 
        ToPrint = () => currentValue() + Convert.ToString(GetVar(ToAddSymbol)); // GetVar will be called during execution
     }
     Index++;
  }
Actions.Add(new Action(() => Console.WriteLine(ToPrint())));
