    public class MyAdListener : AdListener
    {
        Action OnCloseAction;
        public MyAdListener(Action OnCloseAction)
        {
            this.OnCloseAction = OnCloseAction;
        }
        public override void OnAdClosed()
        {
            OnCloseAction?.Invoke();
            base.OnAdClosed();
        }
    }
