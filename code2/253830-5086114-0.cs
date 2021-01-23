    public void Test(object input)
    {
        dynamic textBox = input;
        //Assuming there is a property named Text at runtime
        textBox.Text = "arbitrary string";
    }
