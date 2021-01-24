    <LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:minWidth="25px"
    android:minHeight="25px"
    android:gravity="center">
    <Button
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="swap"
        android:id="@+id/button1"
        android:layout_gravity="center" />
    </LinearLayout>
     private Button btn1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.SetOnTouchListener(new OnSwipeTouchListener(this));
        }
      public class OnSwipeTouchListener : Java.Lang.Object , View.IOnTouchListener
    {
        private  GestureDetector gestureDetector;
       public OnSwipeTouchListener(Context ctx)
        {
            gestureDetector = new GestureDetector(ctx, new GestureListener());
        }
           
        public bool OnTouch(View v, MotionEvent e)
        {
            return gestureDetector.OnTouchEvent(e);
        }
    }
    public class GestureListener : GestureDetector.SimpleOnGestureListener
    {
        private static  int SWIPE_THRESHOLD = 100;
        private static  int SWIPE_VELOCITY_THRESHOLD = 100;
        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            // TODO
            bool result = false;
            try
            {
                float diffY = e2.GetY() - e1.GetY();
                float diffX = e2.GetX() - e1.GetX();
                if (Math.Abs(diffX) > Math.Abs(diffY))
                {
                    if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD)
                    {
                        if (diffX > 0)
                        {
                            onSwipeRight();
                        }
                        else
                        {
                            onSwipeLeft();
                        }
                        result = true;
                    }
                }
                else if (Math.Abs(diffY) > SWIPE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD)
                {
                    if (diffY > 0)
                    {
                        onSwipeBottom();
                    }
                    else
                    {
                        onSwipeTop();
                    }
                    result = true;
                }
            }
            catch (Exception exception)
            {
                _ = exception.StackTrace;
            }
            return result;
        
        }
        public void onSwipeRight()
        {
            Toast.MakeText(Application.Context, "right", ToastLength.Short).Show();
        }
        public void onSwipeLeft()
        {
            Toast.MakeText(Application.Context, "left", ToastLength.Short).Show();
        }
        public void onSwipeTop()
        {
            Toast.MakeText(Application.Context, "top", ToastLength.Short).Show();
        }
        public void onSwipeBottom()
        {
            Toast.MakeText(Application.Context, "up", ToastLength.Short).Show();
        }
    }
