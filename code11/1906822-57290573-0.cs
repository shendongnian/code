    public async void GetLastKnownUpdateStatus(string UUIDStr, short ClientId)
    {
        UpdateStatusInfo x = new UpdateStatusInfo();
        if (Execution.WaitForTask((canceltoken) => {
              x = GetLastKnownUpdateStatusSync(UUIDStr, ClientId); return true;
            }
        ) > Execution.WAIT_TIMEOUT)
        {
            Output.WriteLine("GetLastKnownUpdateStatus: "+ x.State.ToString());
        }
    }
