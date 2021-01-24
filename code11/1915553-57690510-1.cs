        private bool _isProcessing;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (_isProcessing)
               return;
            try
            {
                _isProcessing = true;
                // do some work
            }
            finally
            {
                _isProcessing = false;
            }
        }
    }
