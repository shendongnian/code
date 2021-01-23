     if (this.InvokeRequired)
            {
                //this executes the work on UI thread
                Invoke(new MethodInvoker(delegate
                         {
    
                             DocumentsNavigator.GenerateWordRevisionHistoryDoc(DOC_GenerateVersDocBackgroundWorker, versionsList, Db, (string)(e.Argument));
    
                         }));
            }
            else
            {
    //it will also be executed on UI thread     
       DocumentsNavigator.GenerateWordRevisionHistoryDoc(DOC_GenerateVersDocBackgroundWorker, versionsList, Db, (string)(e.Argument));
    
            }
        }
