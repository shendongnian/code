    private void button1_Click(object sender, EventArgs e)
    {
        if(!button1.Tag.ToString() == "unclicked")
        {
            button1.Tag = "clicked"; //toggle so next time the ELSE will be performed
            fileNumber = 1;
            ImgSave();
        }
        else
        {
            button1.Tag = "unclicked"; //toggle it off again
            ImgSave.exit();
        }
    }
