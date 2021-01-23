    [CustomAction]
    public static ActionResult CustomAction1(Session session)
    {
    session["MY_PROPERTY"] = "abc";
    return ActionResult.Success;
    }
