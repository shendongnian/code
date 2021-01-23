    public void Connect()
    {
        Connect(1);
    }
    private void Connect(int num)
    {
        if (num > 3)
            throw new Exception("Maximum number of attempts reached");
        try
        {
            // do stuff
        }
        catch
        {
            Connect(num++);
        }
    }
