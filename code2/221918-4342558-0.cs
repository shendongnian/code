      private void OnFlick(object sender, FlickGestureEventArgs e)
      {
         var vm = DataContext as SelectedCatalogViewModel;
         if (vm != null)
         {
            // User flicked towards left
            if (e.HorizontalVelocity < 0)
            {
               // Load the next image 
               LoadNextPage(null);
            }
            // User flicked towards right
            if (e.HorizontalVelocity > 0)
            {
               // Load the previous image
               LoadPreviousPage();
            }
         }
      }
