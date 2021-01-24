    public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
    {
        base.PrepareForSegue(segue, sender);
    
        switch (segue.Identifier)
        {
            case "LaunchSecondView":
                {
                    SecondViewClass target = segue.DestinationController as SecondViewClass;
                    target.Person = CurrentPerson;
                }
                break;
        }
    }
