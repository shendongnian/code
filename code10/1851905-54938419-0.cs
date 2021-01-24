    public class AppFrontBackHelper
    {
        public static OnAppStatusListener mOnAppStatusListener;
        private LifecycleCallBack lifecycleCallBack;
        public AppFrontBackHelper()
        {
          
        }
        /**
         * Register status listener, only used in Application
         * @param application
         * @param listener
         */
        public void register(Application application, OnAppStatusListener listener)
        {
            mOnAppStatusListener = listener;
            lifecycleCallBack = new LifecycleCallBack();
            application.RegisterActivityLifecycleCallbacks(lifecycleCallBack);
        }
        public void unRegister(Application application) => application.UnregisterActivityLifecycleCallbacks(lifecycleCallBack);
        public interface OnAppStatusListener
        {
            void onFront();
            void onBack();
        }
        public class LifecycleCallBack : Java.Lang.Object, Application.IActivityLifecycleCallbacks
        {
            public int activityStartCount { get; private set; }
            public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
            {
            }
            public void OnActivityDestroyed(Activity activity)
            {
            }
            public void OnActivityPaused(Activity activity)
            {
            }
            public void OnActivityResumed(Activity activity)
            {
            }
            public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
            {
            }
            public void OnActivityStarted(Activity activity)
            {
                activityStartCount++;
                //A value from 1 to 0 indicates cutting from the background to the foreground
                if (activityStartCount == 1)
                {
                  
                    if (mOnAppStatusListener != null)
                    {
                        mOnAppStatusListener.onFront();
                    }
                }
            }
            public void OnActivityStopped(Activity activity)
            {
                activityStartCount--;
                //A value from 1 to 0 indicates cutting from the foreground to the background
                if (activityStartCount == 0)
                {
                    //从前台切到后台
                    if (mOnAppStatusListener != null)
                    {
                        mOnAppStatusListener.onBack();
                    }
                }
            }
        }
    }
