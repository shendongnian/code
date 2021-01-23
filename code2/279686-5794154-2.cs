    [CustomAction]
    public static ActionResult CustomAction1(Session session)
    {
    string myProperty = session["MY_PROPERTY"];
    return ActionResult.Success;
    }
