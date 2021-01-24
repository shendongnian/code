    void SetEventTriggerState(EventTrigger ET, EventTriggerType ETType, string MethodName, UnityEventCallState NewState) {
        for (int i = 0; i < ET.triggers.Count; i++) {
            EventTrigger.Entry Trigger = ET.triggers[i];
            EventTrigger.TriggerEvent CB = Trigger.callback;
            for (int j = 0; j < CB.GetPersistentEventCount(); j++) {
                if (CB.GetPersistentMethodName(j) == MethodName && Trigger.eventID == ETType) {
                    CB.SetPersistentListenerState(j, NewState);
                }
            }
        }
    }
