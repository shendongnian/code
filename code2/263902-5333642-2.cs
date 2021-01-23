    public ActionResult ShowHistory(string selectedObjects)
    {
        var items = selectedObjects.TrimEnd(';')
                                   .Split(';')
                                   .Select(i => i + ";");
        ...
    }
