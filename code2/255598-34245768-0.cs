    private void printScreenButton_Click(object sender, EventArgs e)
    {
        SendKeys.Send("%{PRTSC}");
        Image img = Clipboard.GetImage();
        img.Save(@"C:\\testprintscreen.jpg");
    }
