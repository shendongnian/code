            private void btnSaveIniFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveFileIni = new SaveFileDialog())
            {
                var strCurentDirectory = Directory.GetCurrentDirectory();
                SaveFileIni.InitialDirectory = strCurentDirectory;
                SaveFileIni.Filter = "INI File|*.ini";
                SaveFileIni.Title = "Save an INI Settings File";
                if (SaveFileIni.ShowDialog() == DialogResult.OK)
                {
                    _loadedConfig = new INIFile(SaveFileIni.FileName);
                    _loadedConfig["UserSettings"]["txtName"] = txtName.Text;
                    _loadedConfig["UserSettings"]["txtSchool"] = txtSchool.Text;
                    _loadedConfig["UserSettings"]["txtClass"] = txtClass.Text;
                    _loadedConfig.Persist();
                }
            }
        }
