           public ProcessWorkItemTypeField Field_AddFieldToWorkItemType()
            {
                ProcessWorkItemTypeField processWorkItemTypeField = null;
                System.Guid processId = Context.GetValue<Guid>("$processId");
    
                VssConnection connection = Context.Connection;
                WorkItemTrackingProcessHttpClient client = connection.GetClient<WorkItemTrackingProcessHttpClient>();
    
                //get the list of fields on the work item item
                Console.Write("Loading list of fields on the work item and checking to see if field '{0}' already exists...", _fieldRefName);
    
                List<ProcessWorkItemTypeField> list = client.GetAllWorkItemTypeFieldsAsync(processId, _witRefName).Result;
    
                //check to see if the field already exists on the work item
                processWorkItemTypeField = list.Find(x => x.ReferenceName == _fieldRefName);
    
                //field is already on the work item, so just return it
                if (processWorkItemTypeField != null)
                {
                    Console.WriteLine("field found");
                    return processWorkItemTypeField;
                }
                else
                {
                    //the field is not on the work item, so we best add it
                    Console.WriteLine("field not found");
                    Console.Write("Adding field to work item...");
    
                    AddProcessWorkItemTypeFieldRequest fieldRequest = new AddProcessWorkItemTypeFieldRequest()
                    {
                        AllowGroups = false,
                        DefaultValue = String.Empty,
                        ReadOnly = false,
                        ReferenceName = _fieldRefName,
                        Required = false
                    };
    
                    processWorkItemTypeField = client.AddFieldToWorkItemTypeAsync(fieldRequest, processId, _witRefName).Result;
    
                    Console.WriteLine("done");
    
                    return processWorkItemTypeField;
                }
            }
