            try
            {
                int.TryParse(textBoxCopyrightYear.Text, out year);
            }
            catch (CopyrightYearOutOfRange ex)
            {
                MessageBox.Show(
                    string.Format("{0}", ex.Message)
                    , "Copyright out of range exception"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation
                    );
            }
