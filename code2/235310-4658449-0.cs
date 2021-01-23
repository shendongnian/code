    Button button = new Button();
    button.Tag = 1;
    
    ...
    
    void pdfButton_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        switch ((int)b.Tag)
        {
            ...
        }
    
    }
