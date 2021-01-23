    if (value == "X")
    {
        path = "c:\\c#\\image1.png";
        pictureBox1.Invoke(new OutputUpdateDelegate (OutputUpdateCallback1),path);
    }
    
    if (value == "Y")
    {
        path = "c:\\c#\\image2.png";
        pictureBox1.Invoke(new OutputUpdateDelegate(OutputUpdateCallback1), path);
    }
    
    delegate void OutputUpdateDelegate(string data);
    
    private void OutputUpdateCallback1(string data)
    {    
       pictureBox1.Image = Image.FromFile(data);
    }
