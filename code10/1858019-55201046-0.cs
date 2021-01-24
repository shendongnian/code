    // existing pdf path
    PdfReader reader = new PdfReader(path);
    PRStream pst;
    PdfImageObject pio;
    PdfObject po;
    // number of objects in pdf document
    int n = reader.XrefSize;
    //FileStream fs = null;
    // set image file location
    //String path = "E:/";
    for (int i = 0; i < n; i++)
    {
    	// get the object at the index i in the objects collection
    	po = reader.GetPdfObject(i);
    	// object not found so continue
    	if (po == null || !po.IsStream())
    		continue;
    	//cast object to stream
    	pst = (PRStream)po;
    	//get the object type
    	PdfObject type = pst.Get(PdfName.SUBTYPE);
    	//check if the object is the image type object
    	if (type != null && type.ToString().Equals(PdfName.IMAGE.ToString()))
    	{
    		//get the image
    		pio = new PdfImageObject(pst);
    		// fs = new FileStream(path + "image" + i + ".jpg", FileMode.Create);
    		//read bytes of image in to an array
    		byte[] imgdata = pio.GetImageAsBytes();
    		try
    		{
    			Stream stream = new MemoryStream(imgdata);
    			FileStream fs = stream as FileStream;
    			if (fs != null) Console.WriteLine(fs.Name);
    		}
    		catch
    		{
    		}
    	}
    }
