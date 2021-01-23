    Guid id= new Guid("{33011A68-D311-E211-A429-005056820002}");    
     switch (context.MessageName)
                    {
                        case "Update":
                            {
                                try
                                {
                                    if (ent.Contains("fieldname") == true)
                                    {
                                       
                                        AssignRequest assign = new AssignRequest
                                        {
                                            Assignee = new EntityReference("systemuser", id),
                                            Target = new EntityReference(ent.LogicalName, ent.Id)
                                        };
                                        _service.Execute(assign);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new InvalidPluginExecutionException("Error" + Environment.NewLine + "Details: " + ex.Message);
                                }
                            }
                            break;
                    }
