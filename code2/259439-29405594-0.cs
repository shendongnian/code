            try
            {
                checked
                {
                    int y = 1000000000;
                    short x = (short)y;
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("hey, we got a overflow/underflow situation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
