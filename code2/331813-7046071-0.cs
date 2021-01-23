    public abstract class BaseLooper<TItem>
    {
        public void DoLoop (List<TItem> list)
        {
            foreach (TItem item in list)
            {
                DoLoopAction(item);
            }
        }
    
        protected abstract void DoLoopAction(TItem item);
    }
    
    public class BlueLooper
        : BaseLooper<BlueClass>
    {
        protected overrides DoLoopAction (BlueClass item)
        {
            ...Do Stuff
        }
    }
