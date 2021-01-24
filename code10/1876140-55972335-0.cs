    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        public bool ThorwExceptionOnSubscribingShownEvent { get; set; } = true;
        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
            {
                var EVENT_SHOWN = typeof(Form).GetField("EVENT_SHOWN",
                    BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null);
                var handlers = Events[EVENT_SHOWN]?.GetInvocationList();
                if (ThorwExceptionOnSubscribingShownEvent && handlers?.Length > 0)
                    throw new InvalidOperationException("Shown event is deprecated.");
            }
            base.OnShown(e);
        }
    }
