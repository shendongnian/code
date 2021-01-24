    Setter setter = new Setter();
    setter.Property = Button.BackgroundProperty;
    setter.Value = imageSourceOff;
    Trigger trigger = new Trigger();
    trigger.Property = IsMouseOverProperty;
    trigger.Value = true;
    trigger.Setters.Add(setter);
    
