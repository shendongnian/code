    private void Init()
            {
                view = ((Activity)cx).LayoutInflater.Inflate(Resource.Layout.MyPage, this);
    
                eventsListAdapter?.Dispose();
                eventsListAdapter = new EventsAdapter(
                    context,
                    EventListDisplay.DefaultView,
                    dateCurrentlyDisplayed);
    
                var myObserver = new MyDataSetObserver();
                eventsListAdapter.RegisterDataSetObserver(myObserver);
    
                MessagingCenter.Subscribe<object>(this, "needRedraw", (sender) => {
                    // do something whenever the "needRedraw" message is sent
                    Redraw();
                });
            }
