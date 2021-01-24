    var fieldValueSet = new FieldValueSet();
                                    fieldValueSet.AdditionalData = new Dictionary<string, object>();
                                    fieldValueSet.AdditionalData.Add("ColumnName@odata.type", "Edm.String");
                                    fieldValueSet.AdditionalData.Add("ColumnName", "DesiredValue");
                                   
        
                                   
                                    await graphServiceClient.Sites["emrisdev.sharepoint.com:/sites/ITOddeleni:"].Lists["TeamsRequest"].Items[item.Id].Fields
                                        .Request()
                                        .UpdateAsync(fieldValueSet);
