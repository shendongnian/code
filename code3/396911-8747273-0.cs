    public class Base
    {
        protected virtual void Execute(IList<Action> actions = null)
        {
            actions = actions ?? new List<Action>();
            // do stuff like begin tran
            foreach (var action in actions)
            {
                action();
            }
            // do stuff like end tran 
        }
    }
    public class Sub : Base
    {
        protected override void Execute(IList<Action> actions = null)
        {
            actions = actions ?? new List<Action>();
            actions.Add(A);
            actions.Add(B);
            base.Execute(actions);
        }
        private void A()
        {
        }
        private void B()
        {
        }
    }
