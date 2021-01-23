    Barcode128 code128 = new Barcode128();
    code128.CodeType = iTextSharp.text.pdf.Barcode.CODE128;
    code128.ChecksumText = true;
    code128.GenerateChecksum = true;
    code128.StartStopText = false;
    code128.Code = <<Barcode value>>;
     
    // Create a blank image 
    System.Drawing.Bitmap bmpimg = new Bitmap(120,35); // provide width and height based on the barcode image to be generated. harcoded for sample purpose
    Graphics bmpgraphics = Graphics.FromImage(bmpimg);
    bmpgraphics.Clear(Color.White); // Provide this, else the background will be black by default
    // generate the code128 barcode
    bmpgraphics.DrawImage(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White), new Point(0, 0));
     
     //generate the text below the barcode image. If you want the placement to be dynamic, calculate the point based on size of the image
    bmpgraphics.DrawString(<<Barcode value>>, new System.Drawing.Font("Arial", 8, FontStyle.Regular), SystemBrushes.WindowText, new Point(15, 24));
    // Save the output stream as gif. You can also save it to external file
    bmpimg.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
