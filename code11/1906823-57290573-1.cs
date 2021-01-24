    public async void GetLastKnownUpdateStatus(string UUIDStr, short ClientId)
    {
        UpdateStatusInfo x = new UpdateStatusInfo();
        if (Execution.WaitForTask((canceltoken) => { 
              x = GetLastKnownUpdateStatus(UUIDStr, ClientId).ConfigureAwait(false).GetAwaiter().GetResult(); return true;
            }
        ) > Execution.WAIT_TIMEOUT)
        {
            Output.WriteLine("GetLastKnownUpdateStatus: "+ x.State.ToString());
        }
    }
