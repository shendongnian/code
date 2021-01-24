    public void CallMeIwillCallYourFunction(Action<string,int> yourFunction)
    {
        yourFunction("HelloWorld", 123);
    }
    
    void yourFunction(string text, int header)
    {
        MessageBox.Show(text, header);
    }
