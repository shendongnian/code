using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xxx;
using xxx.iOS;
[assembly:ExportRenderer(typeof(TabbedPage),typeof(MyTabbedPageRenderer))]
namespace xxx.iOS
{
    public class MyTabbedPageRenderer:TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            MessagingCenter.Subscribe<Object, int>(this, "ChangeStyle", (args, position) => {
                UpdateItem(TabBar.Items[position], "xxx.png","xxx2.png");
            });
        }
        void UpdateItem(UITabBarItem item, string icon,string selectIcon)
         {
            if (item == null)
            {
                return;
            }
                                      
            // set default icon
            if (item?.Image?.AccessibilityIdentifier == icon)
              return;
            item.Image = UIImage.FromBundle(icon);
            item.Image.AccessibilityIdentifier = icon;
            //set select icon
            if (item?.SelectedImage?.AccessibilityIdentifier == selectIcon)
                return;
            item.SelectedImage = UIImage.FromBundle(selectIcon);
            item.SelectedImage.AccessibilityIdentifier = selectIcon;
            //set font
            item.SetTitleTextAttributes(new UITextAttributes() { Font=UIFont.SystemFontOfSize(10,UIFontWeight.Light)},UIControlState.Normal);
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.SystemFontOfSize(10, UIFontWeight.Light) }, UIControlState.Selected);
        }
    }
}
###in Android 
You can check this [blog][1] , it provide the solution in Android by using Custom Renderer .
 
###in Forms
Use **MessagingCenter** to send the message when you want (such as click a button) 
MessagingCenter.Send<Object, int>(this, "ChangeStyle", 0);
  [1]: https://montemagno.com/dynamically-changing-xamarin-forms-tab-icons-when-select/
