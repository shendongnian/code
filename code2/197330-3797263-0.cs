        private void ModelUIElement3D_MouseDown(object sender, MouseButtonEventArgs e)
        {
                if (sender == trololo)
                {
                    RaiseModelClickEvent("auditorium");    
                }
                else if (sender == LogoMouseDown)
                {
                    RaiseModelClickEvent("logo");
                }
            
        }
