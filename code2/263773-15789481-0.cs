    Session.Abandon(); // Does nothing
    Session.Clear();   // Removes the data contained in the session
    Example:
    001: Session["test"] = "test";
    002: Session.Abandon();
    003: Print(Session["test"]); // Outputs: "test"
