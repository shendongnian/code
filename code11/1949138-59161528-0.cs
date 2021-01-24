        sysMan.ActivateConfiguration();
        sysMan.StartRestartTwinCAT();
        System.Threading.Thread.Sleep(10000);    
        ErrorItems ACErrors = dte.ToolWindows.ErrorList.ErrorItems;
        ErrorItem ACErrorsItems;
        int j = 1;
        do
        {
            System.Threading.Thread.Sleep(5000);
            ACErrorsItems = ACErrors.Item(j);
            j++;
            if (ACErrorsItems.ErrorLevel != vsBuildErrorLevel.vsBuildErrorLevelLow)
            {
                Console.WriteLine("Description: " + ACErrorsItems.Description);
            }
        } while (!ACErrorsItems.Description.Contains("| 'PlcTask' (350): | ================"));    
                  
