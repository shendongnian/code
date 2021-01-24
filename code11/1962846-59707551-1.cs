    //...
    var fileFullPath = Path.Combine(_hostingEnvironment.WebRootPath, pdfPath, fileName);
    var fs = _hostingEnvironment.WebRootFileProvider.GetFileInfo(fileFullPath).CreateReadStream();
    long _TotalBytes = fs.Length;
    // attach filestream to binary reader
    using(BinaryReader _BinaryReader = new System.IO.BinaryReader(fs)) {
        // read entire file into buffer
        _Buffer = _BinaryReader.ReadBytes((int)_TotalBytes);
    }
    //...
