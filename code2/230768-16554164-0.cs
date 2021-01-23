    string imag = img;
    imag = imag.Replace("\", "");
    int c = imag.Length % 4;
    if ((c) != 0)
    	imag = imag.PadRight((imag.Length + (4 - c)), "=");
    [] converted = Convert.FromBase64String(imag);
    using (System.IO.MemoryStream vstream = new System.IO.MemoryStream(converted)) {
    	return Image.FromStream(vstream);
    }
