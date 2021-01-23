    // You might also need try/catch for this!
    int cProjectItems = pProject.ProjectItems.Length;
    for(iProjectItem = 0; iProjectItem < cProjectItems; iProjectItem++)
    {
       bool bSucceeded = false;
       while(!bSucceeded)
       {
            try{
                ProjectItem pi = pProject.ProjectItems[iProjectItem];
                // do something with pi
                bSucceeded = true;
            }catch (System.Runtime.InteropServices.COMException loE)
            {
                liCount++;
                if ((uint)loE.ErrorCode == 0x80010001)                      {
                    // RPC_E_CALL_REJECTED - sleep half sec then try again
                    System.Threading.Thread.Sleep(pDelayBetweenRetry);
                }
            }  
       }
        
    }
