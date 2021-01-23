    public class ScrollController : UIViewController
    	{
    		UIScrollView scroll;
    		List<UIButton> buttons;
    		
    		public override void ViewDidLoad ()
    		{
    			base.ViewDidLoad ();
    			
    			scroll = new UIScrollView();
    			scroll.Frame = View.Bounds;
    			View.AddSubview(scroll);
    			
    			scroll.ContentSize = new SizeF(0, 1000);
    			
    			buttons = new List<UIButton>();
    			for(int i = 0; i < 10; i++)
    			{
    				var button = CreateButton(i * 75, i.ToString());
    				buttons.Add(button);
    				scroll.AddSubview(button);
    			}
    		}
    		
    		UIButton CreateButton(float y, string title)
    		{
    			var button = UIButton.FromType(UIButtonType.RoundedRect);
    			button.SetTitle(title, UIControlState.Normal);
    			button.Frame = new System.Drawing.RectangleF(0, y, 200, 50);
    			button.TouchUpInside += HandleButtonTouchUpInside;
    			return button;
    		}
    
    		void HandleButtonTouchUpInside (object sender, EventArgs e)
    		{
    			var button = sender as UIButton;
    			Console.WriteLine("{0} touched", button.Title(UIControlState.Normal));
    		}
    	}
