    public class ChildViewModel
    {
            private IEventAggregator _eventAggregator;
            public ChildViewModel(IEventAggregator eventAggregator)
            {
                _eventAggregator = eventAggregator;
            }
            public void Change()
            {
                _eventAggregator.PublishOnUIThread(new SelectedItemChangedMessage<string>(){ SelectedItem = selectedItem });
            }
    }
