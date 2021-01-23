                AclRule aclRule = new AclRule()
                {
                    Role = "owner",
                    Scope = new AclRule.ScopeData()
                    {
                        Type = "user",
                        Value = email.ToString()
                    }
                };
                _service.Acl.Insert(aclRule, calendarId).Execute();
