        class CustAction : ICustAction
        {
            public void Execute()
            {
            }
        }
        
        class CustActionCollection : ICustAction, ICustActionCollection
        {
            private List<ICustAction> _actions;
        
            public List<ICustAction> Actions
            {
                get
                {
                    if (_actions == null)
                    {
                        _actions = new List<ICustAction>();
                    }
        
                    return _actions;
                }
            }
        
            public void Execute()
            {
                foreach (var action in _actions)
                {
                    action.Execute();
                }
            }
        
            public void ExecuteDistinct()
            {
                List<ICustAction> executionList = GetAllActions();
                foreach (var action in distinctActions(executionList))
                {
                    action.Execute();
                }
            }
        
            public List<ICustAction> GetAllActions()
            {
                Stack<ICustAction> actions = new Stack<ICustAction>();
                List<ICustAction> executionList = new List<ICustAction>();
                actions.Push(this);
        
                while (actions.Count > 0)
                {
                    ICustAction action = actions.Pop();
        
                    if (action is ICustActionCollection)
                    {
                        foreach (var i in ((ICustActionCollection)action).Actions)
                        {
                            actions.Push(i);
                        }
                    }
                    else
                    {
                        executionList.Add(action);
                    }
                }
        
                return executionList;
            }
        
        
            public bool HasDuplicates()
            {
                List<ICustAction> actions = GetAllActions();
                return distinctActions(actions).Count() < actions.Count;
            }
        
            private IEnumerable<ICustAction> distinctActions(IEnumerable<ICustAction> list)
            {
                return list.Distinct();
            }
    }
