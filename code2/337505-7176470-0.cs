            public class Switch
            {
                List<Switch> actionList = new List<Switch>();
                public string Value { get; set; }
                public Action Action { get; set; }
                public void Perform( string target)
                {
                    foreach (Switch act in actionList)
                    {
                        if (target.Contains(act.Value))
                        {
                            act.Action();
                            break;
                        }
                    }
                }
                public void AddBlock(string value, Action act)
                {
                    actionList.Add(new Switch() { Action = act, Value = value });
                }
            }
