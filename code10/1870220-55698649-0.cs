    public void TriggerActions(Player p)
    {
        foreach (var buff in p.Buffs.OfType<IBuffOnActionTrigger>()) {
            buff.OnPlayerAction(p);
        }
    }
    public void TriggerPlayerDie(Player p)
    {
        foreach (var buff in p.Buffs.OfType<IBuffOnPlayerDie>()) {
            buff.OnPlayerDie(p);
        }
    }
