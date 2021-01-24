	public class MyTouchPlusGestures : Java.Lang.Object, View.IOnTouchListener
	{
		readonly MyGestures myGestures = new MyGestures();
		readonly TimeSpan Milli10 = TimeSpan.FromMilliseconds(10);
		readonly GestureDetector gestureDetector;
		DateTime oldTime = DateTime.Now;
		internal class MyGestures : GestureDetector.SimpleOnGestureListener
		{
			public override void OnLongPress(MotionEvent e)
			{
				base.OnLongPress(e);
			}
			public override bool OnDoubleTap(MotionEvent e)
			{
				return base.OnDoubleTap(e);
			}
		}
		public MyTouchPlusGestures(View view)
		{
			gestureDetector = new GestureDetector(view.Context, myGestures);
			view.SetOnTouchListener(this);
		}
		public bool OnTouch(View v, MotionEvent e)
		{
			if (!gestureDetector.OnTouchEvent(e))
			{
				// If the event is not handled in one of your gestures, 
				// fall through to the MotionEventActions switch.
				switch (e.Action)
				{
					case MotionEventActions.Down:
						oldTime = DateTime.Now;
						break;
					case MotionEventActions.Move:
						if (DateTime.Now.Subtract(oldTime) > Milli10)
						{
							Console.WriteLine($"Touch {e.RawX} : {e.RawY} : tD: {DateTime.Now.Subtract(oldTime)}");
							oldTime = DateTime.Now;
						}
						break;
					default:
						break;
				}
			}
			return true;
		}
	}
