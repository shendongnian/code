    [assembly:ExportRenderer(typeof(Picker),typeof(MyPickerRenderer))]
    namespace App6.iOS
    {
      public class MyPickerRenderer:PickerRenderer
      {
        public MyPickerRenderer()
        {
        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                
                UIPickerView pickerView = (UIPickerView)Control.InputView;
                
                // get the button Done and rewrite the event
                UIToolbar toolbar = (UIToolbar)Control.InputAccessoryView;
                UIBarButtonItem done = new UIBarButtonItem("OK", UIBarButtonItemStyle.Done, (object sender, EventArgs click) =>
                {
                                     
                    MessagingCenter.Send<Object>(this,"Ok_Clicked");
                });
                UIBarButtonItem cancel = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (object sender, EventArgs click) =>
                {
                                    
                    MessagingCenter.Send<Object>(this, "Cancel_Clicked");
                });
                UIBarButtonItem empty = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);
                toolbar.Items = new UIBarButtonItem[] { cancel,empty, done };
            }
        }
      }
    }
