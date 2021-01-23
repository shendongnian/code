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
            var params = Tuple.Create<string, GridControl>(queryString, sorgu);
            bw.RunWorkerAsync (params);
        }
        void bw_DoWork (object sender, DoWorkEventArgs e) {
            Tuple<string, GridControl> params = e.Argument as Tuple<string, GridControl>;
            
            ConnectionClass cc = new Connection Class();
            cc.fillGrid(params.Item1, params.Item2);
        }
        void bw_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            progressForm.Close (); //
        }
