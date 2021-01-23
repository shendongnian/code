    public partial class MyForm : Form
    {
        #region Fields & Properties
        Dictionary<int, string> _soundFilepaths;
        #endregion
        #region Constructor & Destructor
        public MyForm()
        {
            InitializeComponent();
            this.EnableSounds();
        }
        #endregion
        #region Events
        private void playSound1_Click(object sender, EventArgs e)
        {
            this.PlaySound(0, 1);
        }
        private void playSound2_Click(object sender, EventArgs e)
        {
            this.PlaySound(0, 2);
        }
        #endregion
        #region Methods
        private void EnableSounds()
        {
            Dictionary<int, string> soundPaths = new Dictionary<int, string>();
            string commandString = "select code_alarme, chemin from alarme";
            using (OdbcConnection conn = new OdbcConnection("DSN=cp1"))
            {
                using (OdbcCommand cmd = new OdbcCommand(commandString, conn))
                {
                    cmd.CommandTimeout = 60;
                    conn.Open();
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            soundPaths.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                        }
                    }
                }
            }
            this._soundFilepaths = soundPaths;
        }
        private void PlaySound(int deviceID, int soundID)
        {
            // I don't have the NAudio library so I can't check if it works or no though.
            disposeWave();
            NAudio.Wave.WaveFileReader waveReader = new NAudio.Wave.WaveFileReader(this._soundFilepaths[soundID]);
            var waveOut = new NAudio.Wave.WaveOut();
            waveOut.DeviceNumber = deviceNumber;
            var output = waveOut;
            output.Init(waveReader);
            output.Play();
        }
        #endregion
    }
