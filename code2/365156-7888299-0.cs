    var _readerGlobal = new PdfReader(@"c:\temp\bicicleta.pdf");
    MemoryStream _thePdfFile = new MemoryStream();
    
    var _documentGlobal = new Document(PageSize.A5, 50, 50, 50, 50);
    
    var _writerGlobal = PdfWriter.GetInstance(_documentGlobal, _thePdfFile);
    _writerGlobal.SetFullCompression();
    
    _documentGlobal.Open();
    
    var _cbGlobal = _writerGlobal.DirectContent;
    PdfImportedPage page1 = _writerGlobal.GetImportedPage(_readerGlobal, 1);
    _cbGlobal.AddTemplate(page1, 1f, 0, 0, 1f, 0, 0);
    
    _documentGlobal.CloseDocument();
    
    var _pdfBytes = _thePdfFile.ToArray();
    File.WriteAllBytes(@"c:\temp\bicicletaA5.pdf", _pdfBytes);
