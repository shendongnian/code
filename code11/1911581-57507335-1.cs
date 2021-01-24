    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        string code = txtQRCode.Text;
    
        var barcodeWriter = new BarcodeWriter();
        barcodeWriter.Format = BarcodeFormat.QR_CODE;
        barcodeWriter.Options.Margin = 0;
        barcodeWriter.Options.Width = 150;
        barcodeWriter.Options.Height = 150;
    
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 150;
        imgBarCode.Width = 150;
    
        using (Bitmap bitMap = barcodeWriter.Write(code))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            PlaceHolder1.Controls.Add(imgBarCode);
        }
    }
