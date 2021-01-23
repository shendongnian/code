    public class Tests {
      private string time;
      [Editor(typeof(TimePickerEditor), typeof(UITypeEditor))]
      public string Time {
        get { return time; }
        set { time = value; }
      }
      internal class TimePickerEditor : UITypeEditor {
        IWindowsFormsEditorService editorService;
        DateTimePicker picker = new DateTimePicker();
        string time;
        public TimePickerEditor() {
          picker.Format = DateTimePickerFormat.Custom;
          picker.CustomFormat = "mm:HH";
          picker.ShowUpDown = true;
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value) {
          if (provider != null) {
            this.editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
          }
          if (this.editorService != null) {
            if (value == null) {
              time = DateTime.Now.ToString("HH:mm");
            }
            this.editorService.DropDownControl(picker);
            value = picker.Value.ToString("HH:mm");
          }
          return value;
        }
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context) {
          return UITypeEditorEditStyle.DropDown;
        }
      }
    }
