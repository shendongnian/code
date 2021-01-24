    aPublicAsyncMethod(ExternalEvent.Create(((_934_PRLoogle_Command06_EE15_CreateNewTags)myWindow2.my__934_PRLoogle_Command06_EE15_CreateNewTags.Clone())));
    public async void aPublicAsyncMethod(ExternalEvent myExternalEvent)
            {
                myExternalEvent.Raise();
    
                while (myExternalEvent.IsPending)
                {
                    await System.Threading.Tasks.Task.Delay(200); 
                }
            }
