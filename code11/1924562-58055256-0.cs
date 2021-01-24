    public class Child
      private Window _Main;
      public Child(Window main)
      {
        _Main = main;
      }
      private void ButtonNazad_Click(object sender, RoutedEventArgs e)
      {
        _Main.WindowState = WindowState.Maximized;
        Close();
      }
    }
