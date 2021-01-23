    try
       {
          _assembly = Assembly.GetExecutingAssembly();
          _imageStream = _assembly.GetManifestResourceStream("MyNamespace.MyImage.bmp");
          _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("MyNamespace.MyXmlFile.xml"));
       }
       catch
       {
          MessageBox.Show("Error accessing resources!");
       }
