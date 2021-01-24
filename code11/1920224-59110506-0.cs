    int itemCount = myGroup.OPCItems.Count;
    object qualities = null;
    object timeStamps = null;
    object errors = null;
    int serverHandles[itemCount];
    Array values = Array.CreateInstance(TypeOf(object), {itemCount },{1})
    for (int i = 0; i < itemCount; i++){
       serverHandles[i] = myGroup.OPCItems.Item(i + 1).ServerHandle;
       values.SetValue("", i);
    }
    myGroup.SyncRead(OPCSiemensDAAutomation.OPCDataSource.OPCDevice, itemCount + 1, ServerHandles, values, errors, qualities, timeStamps);
