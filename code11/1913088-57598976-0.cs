                    Task act = Task.Run(async () => await App.DataService.UpdateItemAsync(CP, ToServer, "Contact_Party/EditContact_Party/" + CP.Id));
                    await act.ContinueWith(async (antecedent) =>
                    {
                        foreach (var sam in specialty)
                        {
                            if (CP.Id > 0)
                            {
                                sam.Cntct_SEQ = CP.Id;
                            }
                            else
                            {
                                sam.Tmp_Cntct_SEQ = CP.Cntct_SEQ;
                            }
                            if (sam.Id == 0)
                            {
                                if (sam.Cntct_Spec_SEQ == 0)
                                    await App.DataService.CreateItemAsync(sam, ToServer, "Contact_Specialty/AddContact_Specialty");
                                else
                                {
                                    await App.DataService.UpdateItemAsync(sam, ToServer, "Contact_Specialty/EditContact_Specialty/" + sam.Id);
                                }
                            }
                            else
                            {
                                await App.DataService.UpdateItemAsync(sam, ToServer, "Contact_Specialty/EditContact_Specialty/" + sam.Id);
                            }
                        }
                    }, TaskContinuationOptions.None); 
