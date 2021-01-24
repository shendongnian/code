    public string SetIsVisible(MessageEventArgs e, bool isVisible)
    {
        OBSSource obsSource = JsonConvert.DeserializeObject<OBSSource>(e.Data);
        obsSource.ItemVisible = isVisible;
        return JsonConvert.SerializeObject(obsSource);
    }
