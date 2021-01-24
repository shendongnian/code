    #region Workaround for fixing UCI app EntityReference coming as empty string
                if (string.IsNullOrEmpty(organizer.Name))
                {
                    ctLog.Log("organizer.Name is empty");
                    fetch = string.Format(@"<fetch>
                                              <entity name='systemuser' >
                                                <attribute name='fullname' />
                                                <filter type='and' >
                                                  <condition attribute='systemuserid' operator='eq' value='{0}' />
                                                </filter>
                                              </entity>
                                            </fetch>", organizer.Id);
                    ctLog.Log("fetch built");
                    results = userOrgService.RetrieveMultiple(new FetchExpression(fetch));
                    ctLog.Log("results count: " + results.Entities.Count);
                    if (results.Entities.Count > 0)
                    {
                        organizer.Name = results.Entities[0].GetAttributeValue<string>("fullname");
                    }
                }
    #endregion
