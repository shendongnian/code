    public ActionResult Copy(string id, string targetId)
    {
        CopyOrMove((x, y) => Copy(x, y));
    }
    public ActionResult Move(string id, string targetId)
    {
        CopyOrMove(id, targetId, (x, y) => Move(x, y));
    }
    private void CopyOrMove(string id, string targetId,
                            Action<string, string> fileAction)
    {
        // lot of similar code
        fileAction(sourcePageRef, destinationPageRef);
        // lot of similar code
    }
