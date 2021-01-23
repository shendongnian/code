        public string AskSaveFile() {
            if (this.InvokeRequired) {
                return (string)Invoke(new Func<string>(() => AskSaveFile()));
            }
            else {
                var sfd = new SaveFileDialog();
                sfd.Filter = "Fichiers txt (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                return sfd.ShowDialog() == DialogResult.OK ? sfd.FileName : null;
            }
        }
