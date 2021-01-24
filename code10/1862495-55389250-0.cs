    Timer _dispatcherTimer;
    TimerCallback timerDelegate;
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_account, container, false);
            init(view);
            timerDelegate = new TimerCallback(Tick);
            return view;
        }
       private void init(View view)
        {
            button = view.FindViewById<Button>(Resource.Id.mybutton);
            button.Click += delegate
            {
                _dispatcherTimer = new System.Threading.Timer(timerDelegate, null, 0, 2000);
            };
        }
        private void Tick(object state)
        {
            this.Activity.RunOnUiThread(() =>
            {
                //do something
                  Random reRandom = new Random();
                  int s = reRandom.Next(1000);
                    button.Text = s.ToString();
            });
        }
