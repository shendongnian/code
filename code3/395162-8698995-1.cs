               for (int i = 0; i < transID.Length; i++)
                    {
                        string TransID = transID[i];
                        string Amt = amount[i];
                        string Cat = category[i];
                        string SharedNo = sharedNum[i];
                        string Msg = message[i];
                        string DateTime = dateTime[i];
                       
                        //create a new instance of activity             
                        AllActivity activity = new AllActivity();  
                        activity.Amt = Amt; 
                        activity.Msg = Msg; 
                        activity.DateTime = DateTime;                    
    
                        ActivityList.Add(activity);
                    }
