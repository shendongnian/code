        private bool _isProcessing;
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isProcessing)
                    return;
                _isProcessing = true;
                // do some work
            }
            finally
            {
                _isProcessing = false;
            }
        }
    }
