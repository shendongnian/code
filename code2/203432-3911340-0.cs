        private void startPPT()
        {
        // as above
        }
        private delegate void CallBackPPTSaved(Presentation p);
        void app_PresentationSave(Presentation Pres)
        {
            this.Dispatcher.BeginInvoke(new CallBackPPT(PPTEventHandler), System.Windows.Threading.DispatcherPriority.Normal, Pres);
        }
        private void PPTEventHandler(Presentation p)
        {
            MessageBox.Show("Saved");
        }
