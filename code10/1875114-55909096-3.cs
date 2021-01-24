	public class MyTouch : Java.Lang.Object, View.IOnTouchListener
	{
		TimeSpan Milli10 = TimeSpan.FromMilliseconds(10);
		DateTime oldTime;
		public bool OnTouch(View v, MotionEvent e)
		{
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
			return true;
		}
	}
