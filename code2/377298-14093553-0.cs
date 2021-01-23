    private void lienzo_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
            {
                Point coordenadas = new Point();
                coordenadas = Mouse.GetPosition(lienzo);
    
                string msg = "Coordenadas mouse :" + coordenadas.X + "," + coordenadas.Y;
                MessageBoxResult resultado;
                string titulo = "Informacion";
                MessageBoxButton botones = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
    
                resultado = MessageBox.Show(msg, titulo, botones, icono);
            }
