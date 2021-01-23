    // this defines a custom UI type editor to display a list of possible benchmarks
    // used by the property grid to display item in edit mode
    public class BenchmarkTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // drop down mode (we'll host a listbox in the drop down)
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            // use a list box
            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;
            // use the IBenchmark.Name property for list box display
            lb.DisplayMember = "Name";
            // get the analytic object from context
            // this is how we get the list of possible benchmarks
            Analytic analytic = (Analytic)context.Instance;
            foreach (IBenchmark benchmark in analytic.Benchmarks)
            {
                // we store benchmarks objects directly in the listbox
                int index = lb.Items.Add(benchmark);
                if (benchmark.Equals(value))
                {
                    lb.SelectedIndex = index;
                }
            }
            // show this model stuff
            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) // no selection, return the passed-in value as is
                return value;
            return lb.SelectedItem;
        }
        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            // close the drop down as soon as something is clicked
            _editorService.CloseDropDown();
        }
    }
