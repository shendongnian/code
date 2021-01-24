      public async Task<ResourceAuthorizationRule> UpdateAuthorizationRuleForQueueAsync(string connectionString, string queuePath, string RuleName, IList<RuleRequest> RuleRequest)
        {
            ResourceAuthorizationRule _sharedAccessAuthorizationRule = new ResourceAuthorizationRule();
            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            var queue = await namespaceManager.GetQueueAsync(queuePath);
            queue.Authorization.Clear();
            int index = connectionString.IndexOf("SharedAccessKeyName=");
            var queueConnectionString = connectionString.Substring(0, index);
            foreach (RuleRequest _authorization in RuleRequest)
            {
                var rightList = new List<Microsoft.ServiceBus.Messaging.AccessRights>();
                foreach (var rule in _authorization.Rights)
                {
                    if (rule.Equals(Models.Azure.AccessRights.Manage))
                    {
                        rightList.AddRange(new[]
                            {Microsoft.ServiceBus.Messaging.AccessRights.Manage, Microsoft.ServiceBus.Messaging.AccessRights.Send, Microsoft.ServiceBus.Messaging.AccessRights.Listen});
                        break;
                    }
                    else
                    {
                        if (rule.Equals(Models.Azure.AccessRights.Send))
                        {
                            rightList.Add(Microsoft.ServiceBus.Messaging.AccessRights.Send);
                        }
                        if (rule.Equals(Models.Azure.AccessRights.Listen))
                        {
                            rightList.Add(Microsoft.ServiceBus.Messaging.AccessRights.Listen);
                        }
                    }
                }
                queue.Authorization.Add(new SharedAccessAuthorizationRule(_authorization.RuleName,
                                        _authorization.PrimaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                        _authorization.SecondaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                        rightList));
            }
            dynamic result = await namespaceManager.UpdateQueueAsync(queue);
            foreach (var _authorization in result.Authorization)
            {
                _sharedAccessAuthorizationRule.Rights = new List<Models.Azure.AccessRights?>();
                if (_authorization.KeyName == RuleName)
                {
                    _sharedAccessAuthorizationRule.Name = _authorization.KeyName;
                    _sharedAccessAuthorizationRule.PrimaryKey = _authorization.PrimaryKey;
                    _sharedAccessAuthorizationRule.SecondaryKey = _authorization.SecondaryKey;
                    foreach (Models.Azure.AccessRights right in _authorization.Rights)
                    {
                        _sharedAccessAuthorizationRule.Rights.Add(right);
                    }
                    _sharedAccessAuthorizationRule.PrimaryConnectionString = queueConnectionString + "SharedAccessKeyName=" + RuleName + ';' + _authorization.ClaimType + '=' + _authorization.PrimaryKey + ";EntityPath=" + queuePath;
                    _sharedAccessAuthorizationRule.SecondaryConnectionString = queueConnectionString + "SharedAccessKeyName=" + RuleName + ';' + _authorization.ClaimType + '=' + _authorization.SecondaryKey + ";EntityPath=" + queuePath;
                }
            }
            return _sharedAccessAuthorizationRule;
        }
