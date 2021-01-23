        public delegate void Savesetting(TabData Tb);
        private Savesetting saveSettingDlg;
        public event Savesetting TriggerSaveSetting {
            add { saveSettingDlg += value; }
            remove { saveSettingDlg -= value; }
        }
        private void SaveData() {
            var handler = saveSettingDlg;
            if (handler != null) handler(_tabdata);
        }
