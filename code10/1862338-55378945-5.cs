    public partial class InstrumentFinderWindowViewModel: UserControl, IInteractionRequestAware
    {
        private void SelectInstrument()
        {
            FinishInteraction?.Invoke();
        }
        public Action FinishInteraction { get; set; }
        public INotification Notification { get; set; }
    }
