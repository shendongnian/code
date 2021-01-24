    public class CustomPicker : PickerRenderer
    {
        List<string> itemList;
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
             
    
            Picker myPicker = Element;
            itemList = myPicker.Items.ToList();
    
            UITextField textField = Control;
            UIPickerView pickerView = textField.InputView as UIPickerView;
            pickerView.Delegate = new MyPickerViewDelegate(itemList,Control);
            textField.InputView = pickerView;
    
            var toolbar = new UIToolbar(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width , 1)) { BarStyle = UIBarStyle.Default, Translucent = true };
            textField.InputAccessoryView = toolbar;
        }
    }
    
    internal class MyPickerViewDelegate : UIPickerViewDelegate
    {
        private List<string> itemList;
        private UITextField textField;
        public MyPickerViewDelegate(List<string> itemList, UITextField control)
        {
            this.itemList = itemList;
            this.textField = control;
        }
    
        //Define the Font size or style
        public override NSAttributedString GetAttributedTitle(UIPickerView pickerView, nint row, nint component)
        {
            var text = new NSAttributedString(
                itemList[(int)row],
                font: UIFont.SystemFontOfSize(24),
                foregroundColor: UIColor.Red,
                strokeWidth: 4
            );
    
            return text;
        }
        //Define the row height
        public override nfloat GetRowHeight(UIPickerView pickerView, nint component)
        {
            return 45;
        }
    
        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UIView contentView = new UIView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, 45));
    
            UILabel label = new UILabel();
            label.Frame = contentView.Bounds;
            contentView.AddSubview(label);
    
            label.Text = itemList[(int)row];
            //Change the label style
            label.BackgroundColor = UIColor.Cyan;
            label.Layer.BorderWidth = 2;
            label.Layer.BorderColor = UIColor.Brown.CGColor;
            label.Layer.CornerRadius = 5;
    
            return contentView;
        }
    
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            //base.Selected(pickerView, row, component);
            textField.Text = itemList[(int)row];
            textField.ResignFirstResponder();
        }
    
    }
