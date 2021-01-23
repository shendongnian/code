         Form progressForm;
         public void func() {
            BackgroundWorker bw = new BackgroundWorker ();
            bw.DoWork += new DoWorkEventHandler (bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler (bw_RunWorkerCompleted);
                       
            progressForm = new Form ();
            ProgressBar pb = new ProgressBar ();
            pb.MarqueeAnimationSpeed = 30;
            pb.Style = ProgressBarStyle.Marquee;
            pb.Dock = DockStyle.Fill;
            progressForm.ClientSize = new Size (200, 50);
            progressForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            progressForm.StartPosition = FormStartPosition.CenterScreen;
            progressForm.Controls.Add (pb);
            progressForm.ControlBox = false;
            progressForm.TopMost = true;
            progressForm.Show ();
            
            string queryString = "SELECT ...."; // fill query string here
            var params = new KeyValuePair<GridControl, string>(sorgu, queryString);
            bw.RunWorkerAsync (params);
        }
        void bw_DoWork (object sender, DoWorkEventArgs e) {
            KeyValuePair<GridControl, string> params = e.Argument as KeyValuePair<GridControl, string>;
            ConnectionClass cc = new Connection Class();
            cc.fillGrid(params.Value, params.Key);
        }
        void bw_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            progressForm.Close (); //
        }
