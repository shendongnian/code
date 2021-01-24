      // inside the Pdf class
      public byte[] Content()
      {
        return this.ReadContentUsingTemporaryFile(TemporaryPdf.TemporaryFilePath());
      }
      private byte[] ReadContentUsingTemporaryFile(string temporaryFilename)
      {
        this._globalSettings["out"] = temporaryFilename;
        HtmlToPdfConverterProcess.ConvertToPdf(this._html, this._globalSettings, this._objectSettings);
        byte[] numArray = TemporaryPdf.ReadTemporaryFileContent(temporaryFilename);
        TemporaryPdf.DeleteTemporaryFile(temporaryFilename);
        return numArray;
      }
