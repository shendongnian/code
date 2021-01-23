    string some_value = null;
    public void reading(object sender, EventArgs e)
    {
        some_value = "Foobar";
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        if (some_value != null)
        {
            // ...
        }
    }
