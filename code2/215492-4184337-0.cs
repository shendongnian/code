    System.Text.ASCIIEncoding encodingASCII = new System.Text.ASCIIEncoding();
    System.Text.UTF8Encoding encodingUTF8 = new System.Text.UTF8Encoding();
    System.Text.UnicodeEncoding encodingUNICODE = new System.Text.UnicodeEncoding();
    var ascii = string.Format("{0}: {1}", encodingASCII.ToString(), encodingASCII.GetString(textBytesASCII));
    var utf =   string.Format("{0}: {1}", encodingUTF8.ToString(), encodingUTF8.GetString(textBytesUTF8));
    var unicode = string.Format("{0}: {1}", encodingUNICODE.ToString(), encodingUNICODE.GetString(textBytesCyrillic));
