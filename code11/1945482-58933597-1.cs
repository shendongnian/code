       <input type="button" value="Click me now"  disabled="@IsDisabled" @onclick="TryLogIn" />
     
    
    @code{ 
    
        bool IsDisabled;
      
        protected override void OnInitialized()
        {
            IsDisabled = false;
        }
    
        async Task TryLogIn()
        {
            IsDisabled = true;
            
            // Do some async work here...
            // Note: Replace your async method with Task.Delay 
            await Task.Delay(5000);
                    
            IsDisabled = false;
      
        }
    
    }
