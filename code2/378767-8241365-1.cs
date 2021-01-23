    System.IO.StreamReader html = new System.IO.StreamReader (
                     "C:\\Documents and Settings\\КОЛЛЕКЦИЯ_РОДНИК_ПРЕМИУМ.html"
                     ,System.Text.Encoding.GetEncoding("iso-8859-15"));
          
    string contenido = html.ReadToEnd();
    html.Close();
    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
    byte[] bytes = System.Text.Encoding.UTF8.GetBytes (contenido);
    string contenidoUTF8 = encoder.GetString(bytes);
    upload.RequestEncoding = System.Text.Encoding.GetEncoding("UTF-8");
    Test.FileManager upload = new Test.FileManager();
    string resultado = upload.TestUploadHTML (contenidoUTF8);
