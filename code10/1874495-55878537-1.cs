    private bool IsEventPublishedConcert(Event l) => l.Published && l.PublishType == EventType.Consert;
    private DateTime GetEventStartTime(Event l) => l.StartTime;
    newItemList = itemList
                  .Where(IsEventPublishedConcert)
                  .OrderBy(GetEventStartTime)
                  .ToList();
