    System.Windows.Interactivity.EventTrigger trigger = 
        new System.Windows.Interactivity.EventTrigger();
    trigger.EventName = "MouseLeftButtonDown";
    PlaySoundAction correct = new PlaySoundAction();
    correct.Source = new Uri("/Sample.wma", UriKind.Relative);
    correct.Volume = 1.0;
    trigger.Actions.Add(correct);
    trigger.Attach(myTextBlock);
