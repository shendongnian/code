    var streamImage = this.printScreenService.CaptureRegionToStream(screenRegion);
    var isBlack = await this.IsBlack(streamImage);
    
    if (isBlack)
    {
        return new OcrModel
        {
            IsBlack = true,
            Texts = new[] { "" }
        };
    } 
    streamImage.Position = 0; //this line
    var localFileOcrResult = await this.client.RecognizePrintedTextInStreamAsync(true, streamImage, OcrLanguages.Fr);
