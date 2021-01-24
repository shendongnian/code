    public virtual bool IsStoreGeneratedAlways
    {
        get => AfterSaveBehavior == PropertySaveBehavior.Ignore || BeforeSaveBehavior == PropertySaveBehavior.Ignore;
        set
        {
            if (value)
            {
                BeforeSaveBehavior = PropertySaveBehavior.Ignore;
                AfterSaveBehavior = PropertySaveBehavior.Ignore;
            }
            else
            {
                BeforeSaveBehavior = PropertySaveBehavior.Save;
                AfterSaveBehavior = PropertySaveBehavior.Save;
            }
        }
    }
