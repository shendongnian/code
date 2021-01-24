    internal async Task<bool> LongFunction()
    {
        // Do some magic.
        // await ...
        return true;
    }
    public void MyFunc()
    {
        using (MyDialog d = new MyDialog())
        {
            d.ShowDialog(this);
        }
    }
