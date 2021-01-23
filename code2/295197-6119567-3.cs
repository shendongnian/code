    public int Parse()
    {
        try
        {
            return int.Parse(textBox1.Text);
        }
        catch (FormatException)
        {
            throw new MyException(textBox1);
        }
    }
