    using System;
    using Foundation;
    using UIKit;
    using ObjCRuntime;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using xxx;
    using xxx.iOS;
    [assembly:ExportRenderer(typeof(MyPicker),typeof(MyPickerRenderer))]
    namespace xxx.iOS
    {
      public class MyPickerRenderer:PickerRenderer
      {
        string SelectedValue;
        public MyPickerRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                SetTimePicker();
            }
        }
        void  SetTimePicker()
        {
            UIDatePicker picker = new UIDatePicker
            {
                Mode = UIDatePickerMode.DateAndTime
            };
            picker.SetDate(NSDate.Now,true);
            picker.AddTarget(this,new Selector("DateChange:"),UIControlEvent.ValueChanged);
            Control.InputView = picker;
            UIToolbar toolbar = (UIToolbar)Control.InputAccessoryView;
            UIBarButtonItem done = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (object sender, EventArgs click) =>
            {
                Control.Text = SelectedValue;
                toolbar.RemoveFromSuperview();
                picker.RemoveFromSuperview();
                Control.ResignFirstResponder();
                MessagingCenter.Send<Object, string>(this, "pickerSelected", SelectedValue);
            });
            UIBarButtonItem empty = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);
            toolbar.Items = new UIBarButtonItem[] { empty, done };
        }
        [Export("DateChange:")]
        void DateChange(UIDatePicker picker)
        {
            NSDateFormatter formatter = new NSDateFormatter();
            formatter.DateFormat = "MM-dd HH:mm aa"; //you can set the format as you want
            Control.Text = formatter.ToString(picker.Date);
            SelectedValue= formatter.ToString(picker.Date);
            MessagingCenter.Send<Object, string>(this,"pickerSelected",SelectedValue);
        }
      }
    }
