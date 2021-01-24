    public class PushButton_ViewModel : PluginModel, IPlugin
    {
        // How was this going to work? Who makes the instance?
        //public PushButton_ViewModel(params object[] settings)
        //{
        //    NameUC = (string)settings[2];
        //    Layout = new LayoutPropertyViewModel();
        //}
        public ICallbacks Callbacks { get; set; }
        public override double Left
        {
            get => Layout.UCLeft;
            set => Layout.UCLeft = value;
        }
        public override double Top
        {
            get => Layout.UCTop;
            set => Layout.UCTop = value;
        }
        public override double Width
        {
            get => Layout.Width;
            set => Layout.Width = value;
        }
        public override double Height
        {
            get => Layout.Height;
            set => Layout.Height = value;
        }                         
    }
