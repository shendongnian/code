    foreach(Activity a in innerSequence.Activities)
    {
        if (a.GetType().IsSubclassOf(typeof(UiPath_Activities_Templates.Scoped_Activity_Template)))
        {
            Scoped_Activity_Template vet = null;
            vet = (Scoped_Activity_Template) a;
            vet.UpdateTestVariable("changed");
        }
    }
