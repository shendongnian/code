using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xxx.iOS;
using Foundation;
using UIKit;
using ObjCRuntime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly:ExportRenderer(typeof(ContentPage),typeof(MyPageRenderer))]
namespace xxx.iOS
{
    public class MyPageRenderer:PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("KeyboardWillShow"), new NSString("UIKeyboardWillShowNotification"), null);
            NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("KeyboardWillHide"), new NSString("UIKeyboardWillHideNotification"), null);
        }
        [Export("KeyboardWillShow")]
        void KeyboardWillShow()
        {
        }
        [Export("KeyboardWillHide")]
        void KeyboardWillHide()
        {
        }
    }
}
