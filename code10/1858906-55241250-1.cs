    else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
					
                using (var sequenceEnum = snapshot.Children.GetEnumerator())
                {
                 for(int i = 0 ;i<snapshot.Children.Count();i++){
					while (sequenceEnum.MoveNext())
                    {
                      try{
				          IDictionary dictUser =(IDictionary)sequenceEnum.Current.Value;
								 
                          Debug.Log("displayName:"+dictUser["displayName"]);
									
                        }
                        catch(System.Exception e){
                            Debug.Log(e.Message);
                        }
						Debug.Log("At The End!");
                    UIManager.instance.ShowOtherUsers(); // Now it executes like a Charm 
             }
