            bool? testRes = yourClass.test();
            if (testRes.HasValue)
            {
                if (testRes == true)
                {
                    MessageBox.Show("True"); 
                }
                else
                {
                    MessageBox.Show("False"); 
                }
            }
            else 
            { 
                MessageBox.Show("no Value"); 
            }
