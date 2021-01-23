    public class CustomRootElement : RootElement
    {
        public CustomRootElement(string caption, RadioGroup group) : base(caption, group)
        {
        
        }
        protected override MonoTouch.UIKit.UIViewController MakeViewController()
        {
            DialogViewController result = (DialogViewController)base.MakeViewController();
            // set the background here
            result.TableView.BackgroundColor = UIColor.ScrollViewTexturedBackgroundColor;
            return result;
        }
    }
