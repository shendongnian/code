    // Created an empty form with a LabelX control on it.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Added this event from the property manager.
        private void labelX1_MassChanged(object sender, EventArgs e)
        {
            var label = (LabelX)sender;
            if (label.Mass <= 0.0)
                MessageBox.Show("Mass is less than or equal to 0");
        }
    }
    public class LabelX : Label
    {
        private float _mass;
        public float Mass
        {
            get { return _mass; }
            set
            {
                if (!value.Equals(_mass))
                {
                    _mass = value;
                    OnMassChanged(EventArgs.Empty);
                }
            }
        }
        public event EventHandler MassChanged;
        protected virtual void OnMassChanged(EventArgs e)
        {
            if (MassChanged != null)
                MassChanged(this, e);
        }
    }
