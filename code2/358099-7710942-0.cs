    public void Button1Click(object sender, EventArgs e)
    {
        ..
        string filename = Path.GetFileName(FileUpload1.FileName);
        ...
        Session["filename"]=filename;
    }
