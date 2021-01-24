    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CameraWeight cw = new CameraWeight();
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = cw.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cw.Increase();
            label1.Text = cw.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cw.Decrease();
            label1.Text = cw.ToString();
        }
    }
    public class CameraWeight
    {
        private int _m_Weight0 = 1000;
        private int _m_Weight1 = 0;
        private int _m_Weight2 = 0;
        public double m_Weight0
        {
            get { return (double)_m_Weight0/10; }
        }
        public double m_Weight1
        {
            get { return (double)_m_Weight1/10; }
        }
        public double m_Weight2
        {
            get { return (double)_m_Weight2/10; }
        }
        public void Increase()
        {
            if(_m_Weight0 > 0)
            {
                _m_Weight0 += -1;
                _m_Weight1 += 1;
            }
            else if (_m_Weight1 > 0.0)
            {
                _m_Weight1 += -1;
                _m_Weight2 += 1;
            }
        }
        public void Decrease()
        {
            if (_m_Weight2 > 0.0)
            {
                _m_Weight2 += -1;
                _m_Weight1 += 1;
            }
            else if (_m_Weight1 > 0.0)
            {
                _m_Weight1 += -1;
                _m_Weight0 += 1;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", m_Weight0.ToString("F1"), m_Weight1.ToString("F1"), m_Weight2.ToString("F1"));
        }
    }
