    public class ActionManager
    {
        public static List<ActionControl> Actions { get; set; } = new List<ActionControl>();
        public static void PerformActions() {
            var sequence = Actions.Where(c => c.Control.Checked).OrderBy(a => a.ActionPriority);
            foreach (var action in sequence) {
               action.Action?.Invoke();
            }
        }
        public class ActionControl
        {
            public ActionControl(Action action, CheckBox control, int priority) {
                this.Action = action;
                this.Control = control;
                this.ActionPriority = priority;
            }
            public Action Action { get; }
            public CheckBox Control { get; }
            internal int ActionPriority { get; }
        }
    }
