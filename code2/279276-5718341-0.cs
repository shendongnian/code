    private Form2 _f2;
    public void openForm2()
    {
        _f2 = new Form2();
        _f2.Show(this); // the "this" is important, as this will keep Form2 open above 
                        // Form1.
    }
    public void closeForm2()
    {
        _f2.Close();
        _f2.Dispose();
    }
