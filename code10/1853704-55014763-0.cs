    public class ScreenListener
    {
        private Context mContext;
        private ScreenBroadcastReceiver mScreenReceiver;
        private static ScreenStateListener mScreenStateListener;
        public ScreenListener(Context context)
        {
            mContext = context;
            mScreenReceiver = new ScreenBroadcastReceiver();
        }
        /**
         * screen BroadcastReceiver
         */
        private class ScreenBroadcastReceiver : BroadcastReceiver
        {
        private String action = null;
            public override void OnReceive(Context context, Intent intent)
            {
                action = intent.Action;
                if (Intent.ActionScreenOn == action)
                { // screen on
                    mScreenStateListener.onScreenOn();
                }
                else if (Intent.ActionScreenOff == action)
                { // screen off
                    mScreenStateListener.onScreenOff();
                }
                else if (Intent.ActionUserPresent == action)
                { // unlock
                    mScreenStateListener.onUserPresent();
                }
            }
        }
    /**
     * begin to listen screen state
     *
     * @param listener
     */
    public void begin(ScreenStateListener listener)
    {
        mScreenStateListener = listener;
        registerListener();
        getScreenState();
    }
    /**
     * get screen state
     */
    private void getScreenState()
    {
        PowerManager manager = (PowerManager)mContext
                .GetSystemService(Context.PowerService);
        if (manager.IsScreenOn)
        {
            if (mScreenStateListener != null)
            {
                mScreenStateListener.onScreenOn();
            }
        }
        else
        {
            if (mScreenStateListener != null)
            {
                mScreenStateListener.onScreenOff();
            }
        }
    }
    /**
     * stop listen screen state
     */
    public void unregisterListener()
    {
        mContext.UnregisterReceiver(mScreenReceiver);
    }
    /**
     * regist screen state broadcast
     */
    private void registerListener()
    {
        IntentFilter filter = new IntentFilter();
        filter.AddAction(Intent.ActionScreenOn);
        filter.AddAction(Intent.ActionScreenOff);
        filter.AddAction(Intent.ActionUserPresent);
        mContext.RegisterReceiver(mScreenReceiver, filter);
    }
    public interface ScreenStateListener
    {// Returns screen status information to the caller
        void onScreenOn();
        void onScreenOff();
        void onUserPresent();
    }
    }
