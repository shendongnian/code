    private void ShowCurrentWindows()
    {
       foreach (Window window in Application.Current.Windows)
       {
            if (!window.IsVisible)
            {
                window.Show();
            }
        }
    }
    private void HideCurrentWindows()
    {
         foreach (Window window in Application.Current.Windows)
         {
             if (window.IsVisible)
             {
                window.Hide();
             }
         }
    }
