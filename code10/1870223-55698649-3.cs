    public void Trigger(TriggerType triggerType, Player p)
    {
        switch (triggerType) {
            case TriggerType.None:
                break;
            case TriggerType.Action:
                TriggerActions(p);
                break;
            case TriggerType.PlayerDie:
                TriggerPlayerDie(p);
                break;
            default:
                break;
        }
    }
