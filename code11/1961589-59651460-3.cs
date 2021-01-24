    public void Test()
    {
        Action a = () => { textBox1.Text = "A"; };
        if (textBox1.InvokeRequired)
        {
            textBox1.Invoke(a);
        }
        else
        {
            a();
        }
    }
