    public delegate string YourDelegate(string number);
    SortedList<string, YourDelegate> methods = new SortedList<string, YourDelegate>();
    // Add more methods here
    methods .Add("Test", Test);
    ...
    public string CallMethod(string methodName, string number)
    {
        YourDelegate method;
        if (methods.TryGetValue(methodName, out method))
            return method(number);
        else
            return "Unknown method";
    }
    ...
    public void button1_Click(object sender, EventArgs e)
    {
        tbResult.Text = CallMethod(tbFunction.Text, tbArgument.Text);
    }
