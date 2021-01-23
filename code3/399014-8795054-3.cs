    static void Main()
    {
        var StrCmpLogical = new SafeStrCmpLogical();
        var relation = StrCmpLogical.Invoke("first", "second");
        var DwmIsCompositionEnabled = new SafeDwmIsCompositionEnabled();
        var enabled = DwmIsCompositionEnabled.Invoke();
    }
