    public void TTCheckAll(Queue<string> symbol, Dictionary<string, bool> model)
    {
        if (symbol.Count == 0)
        {
            PLTrue(model);
        }
        else
        {
            string topSymbol = symbol.Dequeue();
    		TTCheckAll(new Queue<string>(symbol), ReturnDict(model, topSymbol, true));
            TTCheckAll(new Queue<string>(symbol), ReturnDict(model, topSymbol, false));
        }
    }
