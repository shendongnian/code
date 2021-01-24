    public class ForceUpdateSizeTriggerAction : TriggerAction<VisualElement>
    {
        public int HeighRequest { set; get; }
        public ForceUpdateSizeTriggerAction() : base()
        {
        }
        protected override void Invoke(VisualElement sender)
        {
            var parent = sender.Parent;
            while (parent != null && !(parent is ViewCell))
            {
                parent = parent.Parent;
            }
            if (parent is ViewCell cell)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    sender.HeightRequest = HeighRequest;
                    cell.ForceUpdateSize();
                });
            }
        }
    }
