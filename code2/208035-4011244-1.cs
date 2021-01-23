    void TestImage()
    {
        MyImage image = new MyImage();
        try
        {
            image.Load("@C:\My Documents\image001.png");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
