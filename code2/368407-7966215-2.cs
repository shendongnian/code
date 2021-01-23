    void Absorb(Action action)
    {
         try { action(); } catch { };
    }
    // ....
    Absorb(() => ExternalDevice.Call1());
    Absorb(() => ExternalDevice.Call2());
    Absorb(() => ExternalDevice.Call3());
