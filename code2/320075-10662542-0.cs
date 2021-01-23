        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            String p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CompanyName");
            string[] ss = Directory.GetDirectories(p, "ProjectName.*");
            foreach (string s in ss)
            {
                if(MessageBox.Show("Delete " + s + "?","Delete Settings?",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Directory.Delete(s, true);
            }
            base.Uninstall(savedState);
        }
