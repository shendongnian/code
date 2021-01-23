    var cacheRequest = new CacheRequest 
                    { 
                        AutomationElementMode = AutomationElementMode.None,
                        TreeFilter = Automation.RawViewCondition
                    };
                    cacheRequest.Add(AutomationElement.NameProperty);
                    cacheRequest.Add(AutomationElement.AutomationIdProperty);
                    cacheRequest.Push();
                    var targetText = loginLinesDetails[i].FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "TextBlock"));
                    cacheRequest.Pop();
                    var myString = targetText.Cached.Name;
