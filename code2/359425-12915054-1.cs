    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Barcode barcode = new Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE93;
            BarcodeLib.SaveTypes y = SaveTypes.JPG;
            barcode.Encode(type, "12344");
           
            barcode.SaveImage(Server.MapPath("~/Barcode\\abc.jpg"), y);
                        Label1.Text = "Image Saved successfully";
            
        }
        catch (Exception EE)
        {
            EE.ToString();
        }
    }
