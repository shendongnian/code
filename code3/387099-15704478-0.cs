            NavigationService.GoBack(); // if you want to go back        
            // or if you want to exit
            try
            {
                while(NavigationService.CanGoBack)
                    NavigationService.RemoveBackEntry();
            }
            catch (InvalidOperationException)
            {
            }
        }`
