    public class ContainsSwitch
    {
        List<ContainsSwitch> actionList = new List<ContainsSwitch>();
        public string Value { get; set; }
        public Action Action { get; set; }
        public bool SingleCaseExecution { get; set; }
        public void Perform( string target)
        {
            foreach (ContainsSwitch act in actionList)
            {
                if (target.Contains(act.Value))
                {
                    act.Action();
                    if(SingleCaseExecution)
                        break;
                }
            }
        }
        public void AddCase(string value, Action act)
        {
            actionList.Add(new ContainsSwitch() { Action = act, Value = value });
        }
    }
