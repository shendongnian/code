        private void RichTextBox1_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.FormatToApply == "Bitmap")
            {
                e.CancelCommand();
            }
        }
