    foreach (var repeaterAction in conditionTimes.Keys.ToArray())
    {
        if (repeaterAction.Condition() == true)
        {
            if (conditionTimes[repeaterAction] == TimeSpan.Zero)
            {
                repeaterAction.Action();
            }
            else if (conditionTimes[repeaterAction] >= repeaterAction.InitialLapse)
            {
                repeaterAction.Action();
                conditionTimes[repeaterAction] -= repeaterAction.ActionInterval;
            }
            conditionTimes[repeaterAction] += gameTime.ElapsedGameTime;
        }
        else
        {
            conditionTimes[repeaterAction] = TimeSpan.Zero;
        }
    }
