    namespace Screens.Forms
    {
        public partial class Splash : DevExpress.XtraEditors.XtraForm
        {
            public Splash()
            {
                InitializeComponent();
            }
            string RandomLoadingMessage()
            {
                string[] lines ={
                    "Pripremam warp pogon",
                    "Moj drugi ekran za učitavanje je brži, probaj njega",
                    "Verzija programa koju imam u testiranju imala je smiješnije poruke"
                };
                return lines[new Random().Next(lines.Length)];
            }
            public void RandomizeText()
            {
                lblMessage.Text = RandomLoadingMessage();
            }
            private void Splash_Load(object sender, EventArgs e)
            {
                RandomizeText();
            }
            private static Splash _splash;
            private static bool _shouldClose;
            static void ThreadFunc()
            {
                _splash = new Splash();
                _splash.Show();
                while (!_shouldClose)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    if (new Random().Next(1000) < 10)
                    {
                        _splash.Invoke(new MethodInvoker(_splash.RandomizeText));
                    }
                }
                for (int n = 0; n < 18; n++)
                {
                    Application.DoEvents();
                    Thread.Sleep(60);
                }
                if (_splash != null)
                {
                    _splash.Close();
                    _splash = null;
                }
            }
            static public void ShowSplash()
            {
                _shouldClose = false;
                Thread t = new Thread(ThreadFunc);
                t.Priority = ThreadPriority.Lowest;
                t.Start();
            }
            internal static void RemoveSplash()
            {
                _shouldClose = true;
            }
            internal static void ShowSplash(List<string> fromTwitterMessages)
            {
                ShowSplash();
            }
        }
    }
