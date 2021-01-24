    public Task<string> MethodA(MyViewModel model)
    {
        var businessEntity = Convert(model);
        return _pdfService.GenerateBuild(businessEnitty);
    }
    
    public Task<PdfContent> MethodC(string ticket)
    {
        if (_pdfService.TryGet(ticket, out var pdf)
            return StreamContent(pdf.Stream);
    
        return HttpCode(425); //Too early
    }
