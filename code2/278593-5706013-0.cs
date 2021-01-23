    public class MyPage : Page
    {
        protected override void RaisePostBackEvent(
            IPostBackEventHandler sourceControl, 
            string eventArgument
        )
        {
            // here is the control that caused the postback
            var postBackControl = sourceControl;
            base.RaisePostBackEvent(sourceControl, eventArgument);
        }
    }
