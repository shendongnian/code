    public IEnumerable<IResult> Rescue(Exception ex)
    {
        yield return Busy.MakeNotBusy();
        // in practice pass exception details through to notification
        yield return new NotificationPopup("Save station failed");
    }
    [Rescue]
    public IEnumerable<IResult> SaveStation()
    { 
        yield return Busy.MakeBusy();
        yield return new StationSave(_station);
        yield return Busy.MakeNotBusy();
        yield return Show.Tab<StationBrowseViewModel>();
    }
