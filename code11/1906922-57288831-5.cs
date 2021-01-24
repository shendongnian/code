    private void button1_FirstClick(object sender, EventArgs e)
    {
        button1.Clicked -= button1_FirstClick;             
        button1.Clicked += button1_SecondClick;             
        fileNumber = 1;
        ImgSave();
    }
    private void button1_SecondClick(object sender, EventArgs e)
    {
        button1.Clicked -= button1_SecondClick;             
        button1.Clicked += button1_FirstClick;             
        ImgSave.exit();
    }
