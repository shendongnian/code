    public ActionResult ShowHistory(string selectedObjects)
    {
        var items = selectedObjects.Split(';')
                                   .Where(i => !string.IsNullOrEmpty(i))
                                   .Select(i => i + ";");
        ...
    }
