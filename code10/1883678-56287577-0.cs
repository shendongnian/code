     public void TTCheckAll(Queue<string> symbol, Dictionary<string, bool> model,bool value )
    {
        if (symbol.Count == 0)
        {
            PLTrue(model);
        }
        else
        {
            string topSymbol = symbol.Dequeue();
            TTCheckAll(symbol, ReturnDict(model, topSymbol, value),(value?false:true));
            
        }
    }
