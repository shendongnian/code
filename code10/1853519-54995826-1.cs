        private void f_main_Load(object sender, EventArgs e)
        {
            VerifyUpdate();
        }
        //verifies that the local version 
        //is different from the remote version
        private void VerifyUpdate()
        {
            //version local assembly version
            var vlocal = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            //download remote version
            var vremot = new Version(DoenloadVersion().FirstOrDefault());
            var result = vlocal.CompareTo(vremot);
            if (result < 0)
            {
                UpdateQuestion();
            }
            else if (result > 0)
            {
                DowngradeQuestion();
            }
            else
            {
                AlreadyUpdateQuestion();
            }
        }
        //downloads the file containing the latest 
        //version number
        private string[] DoenloadVersion()
        {
            string remoteUri = "https://storage.googleapis.com/albtoos_pessoal/version-remote.txt";
            string localsave = ($"{System.IO.Directory.GetParent(@"../../").FullName}/version-remote.txt");
            WebClient webversion = new WebClient();
            //makes a copy of the remote version in the root folder
            webversion.DownloadFile(remoteUri, localsave);
            return File.ReadAllLines(localsave);
        }
        private void AlreadyUpdateQuestion()
        {
            DialogResult option = MessageBox.Show("You already have the last version!", "Program", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (option == DialogResult.Yes)
            {
                //do something
            }
        }
        private void UpdateQuestion()
        {
            DialogResult option = MessageBox.Show("Need Update", "Program", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (option == DialogResult.Yes)
            {
                //do download
            }
        }
        private void DowngradeQuestion()
        {
            DialogResult option = MessageBox.Show("Need Downgrade", "Program", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (option == DialogResult.Yes)
            {
                //do downgrade
            }
        }
