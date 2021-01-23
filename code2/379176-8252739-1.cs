     public override void OnNavigatedTo(object sender, NavigationEventArgs e)
        {
           base.OnNavigatedTo(sender,e);
            if (App.Activated)
                  if (NavigationService.CanGoBack){
                         NavigationService.GoBack();
                         return; //remember that GoBack() is async and will not cause this function to end early! you must return
    
                  }
                  else { App.Activated = false; } 
                         
            }
        
        }
