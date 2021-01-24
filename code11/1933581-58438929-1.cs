    internal interface IScopedProcessingService {
        Task DoWork();
    }
    //...
    public async Task DoWork() {
        _executionCount = _senderLogRepository.SenderLogs.Count();
        var logMessage = new StringBuilder();
        logMessage.AppendLine($"Начинаю рассылку № {_executionCount}.");
        // get all templates. THIS CALL IS A SOURCE OF PROBLEMS
        var templates = _pushTemplateRepository.PushTemplates.Where(x => x.isActive)
            .Include(x => x.Messages)
            .ThenInclude(x => x.PushLang)
            .Include(x => x.Category)
            .Include(x => x.AdvertiserPushTemplates)
            .ThenInclude(x => x.Advertiser)
            .ToList();
    }
