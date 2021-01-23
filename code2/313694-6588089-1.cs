    [Activity(Label = "Daraize Tech")]
    public class Splash : Activity
    {
        private int _milliseconds;
        private DateTime _dt;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _milliseconds = Intent.GetIntExtra("Milliseconds", 1000);
            SetContentView(Resource.Layout.Splash);
            _dt=DateTime.Now.AddMilliseconds(_milliseconds);
         }
    
        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
    
            new Thread(new ThreadStart(() =>
                                        {
                                        while (DateTime.Now < _dt)
                                            Thread.Sleep(10);
                                        RunOnUiThread( Finish );                                                   
                                        }
                )).Start();
        }
    
    }
