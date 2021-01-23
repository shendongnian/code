    private static object fooLock = new object();
    void foo(object sender, ItemCheckedEventArgs e)
    {
        lock (fooLock)
        {
            if (e.Item.Checked) 
            {
                if (bar(e.Item.Index)) 
                {
                    MessageBox.Show( ... )
                    e.Item.Checked = false;
                }
            }
        }
    }
