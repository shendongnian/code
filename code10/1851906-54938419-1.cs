    [Application]
    public class MyApplication : Application,AppFrontBackHelper.OnAppStatusListener
    {
        protected MyApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            AppFrontBackHelper appFrontBackHelper = new AppFrontBackHelper();
            appFrontBackHelper.register(this, this);
        }
        public void onBack()
        {
            Toast.MakeText(this, "from front to back", ToastLength.Short).Show();
        }
    
        public void onFront()
        {
            Toast.MakeText(this, "from back to front", ToastLength.Short).Show();
        }
        
    }
