    public class MainActivity : AppCompatActivity,View.IOnTouchListener
	  {
        private SKCanvasView skiaView;
	    protected override void OnCreate(Bundle savedInstanceState)
		  {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
            skiaView= FindViewById<SKCanvasView>(Resource.Id.skiaView);
            skiaView.SetOnTouchListener(this);  
            ...
          }
        public bool OnTouch(View v, MotionEvent e)
          {
            Toast.MakeText(this,"touch",ToastLength.Short).Show();
            return true;
          }
      }
