        public MyWinForm1(Scan scanner)
        {
            if (scanner != null)
                scanner.ScanHistoryEvent += new EventHandler<SetScanHistoryEvents>(scanner_ScanHistoryEvent);
        }
        private void scanner_ScanHistoryEvent(object sender, SetScanHistoryEvents e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // txtScanHistory is a TextBox
                txtScanHistory.Text += text + Environment.NewLine;
            });
        }
