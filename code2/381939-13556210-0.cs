    public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyEventChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            if (Application.OpenForms.Count > 0 && Application.OpenForms[0].InvokeRequired)
                Application.OpenForms[0].Invoke(new MethodInvoker(() => PropertyChanged(this, new PropertyChangedEventArgs(propertyName))));
            else
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
