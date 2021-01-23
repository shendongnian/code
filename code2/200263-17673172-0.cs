    //for image alignment:
    <br/>
    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(MapPath("~/images/HKVictoriaHarbour.png"));
    <br/>
    **`image1.Alignment = iTextSharp.text.Image.ALIGN_CENTER;`**
    <br/>
    doc.Add(image1);
