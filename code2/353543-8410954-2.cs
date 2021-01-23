    anothertest.Utility.ServiceHelper.UsingContract<anothertest.IMyService>
                ("TestJeph",
                svc=>
                {
                    string test = svc.UpdateCMPStatus("test", "me");
                }); 
