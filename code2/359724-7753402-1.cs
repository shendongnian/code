        bool IsMouse = false;
        private void cmbMy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsMouse)
            {
                //Write the logic if selection is changed by mouse
            }
            else
            {
                //Write the logic if selection is changed by keyboard
            }
            IsMouse = false;
        }
        private void cmbMy_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            IsMouse = true;
        }
