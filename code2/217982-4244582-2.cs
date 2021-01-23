    public static Tout IfNotNull<Tin, Tout>(this Tin instance, Func<Tin, Tout> Output)
    {
        if (instance == null)
            return default(Tout);
        else
            return Output(instance);
    }
