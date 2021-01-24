        private void BtnMoveText_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == string.Empty)
            {
                MessageBox.Show(@"TextBox is empty, please input a string.");
                return;
            }
            if (_number > txtInput.TextLength)
                _number = 1;
            lblOutput.Text = txtInput.Text.Substring(_number) + txtInput.Text.Substring(0, _number);
            _number++;
            #region ** Depending on Microsoft **
             /*
               Substring(Int32)
                 (Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.)
               Parameters
                   startIndex Int32
                   The zero-based starting character position of a substring in this instance.
          .......................
               Substring(Int32, Int32) 
                (Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length..)
               Parameters
                   startIndex Int32
                   The zero-based starting character position of a substring in this instance.
                   length Int32                
                   The number of characters in the substring.
           */
            #endregion
        }
