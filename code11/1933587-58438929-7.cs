    //...
    public async Task DoWork(CancellationToken stoppingToken) {
        _executionCount = _senderLogRepository.SenderLogs.Count();
        var logMessage = new StringBuilder();
        logMessage.AppendLine($"Начинаю рассылку № {_executionCount}.");
        // get all templates.
        var templates = _pushTemplateRepository.PushTemplates.Where(x => x.isActive)
            .Include(x => x.Messages)
            .ThenInclude(x => x.PushLang)
            .Include(x => x.Category)
            .Include(x => x.AdvertiserPushTemplates)
            .ThenInclude(x => x.Advertiser)
            .ToList();
        //...
    }
