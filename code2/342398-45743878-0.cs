    public partial class MyViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
    
            ConfigurePicker();
        }
    
        void ConfigurePicker()
        {
            var pickerTextField = new UITextField();
            var picker = new UIPickerView
            {
                Model = new PickerViewModel(),
                ShowSelectionIndicator = true
            };
            var screenWidth = UIScreen.MainScreen.Bounds.Width;
            var pickerToolBar = new UIToolbar(new RectangleF(0, 0, (float)screenWidth, 44)) { BarStyle = UIBarStyle.Default, Translucent = true };
            var flexibleSpaceButton = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, e) => pickerTextField.ResignFirstResponder());
            pickerToolBar.SetItems(new[] { flexibleSpaceButton, doneButton }, false);
            pickerTextField.InputView = emotionPicker;
            pickerTextField.InputAccessoryView = pickerToolBar;
        }
        class PickerViewModel : UIPickerViewModel
        {
            int[] _pickerSource = new []{ 1, 2, 3, 4, 5 };
            public override nint GetRowsInComponent(UIPickerView pickerView, nint component) => _pickerSource.Count;
            public override string GetTitle(UIPickerView pickerView, nint row, nint component) => _pickerSource[(int)row];
            public override nint GetComponentCount(UIPickerView pickerView) => 1;
        }
    }
