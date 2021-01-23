    void Absorb(params Action[] actions)
    {
         foreach (var action in actions) try { action(); } catch { };
    }
    So you can
    Absorb(ExternalDevice.Call1, ExternalDevice.Call2, ExternalDevice.Call3);
