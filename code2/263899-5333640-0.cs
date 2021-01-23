    public ActionResult ShowHistory(string selectedObjects)
    {
        foreach (string tempItem in selectedObjects.Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries))
        {
            string item = tempItem + ";"; // Add back on the ; character
        }
        // .. do something
