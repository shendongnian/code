    <button @onclick="Demo">Click</button>
    <span>@stringSize</span>
    
    @code {
    
        long  size = 1234567890;
        string stringSize = "";
    
        private void Demo()
        { 
            stringSize = (size).ToString("#,##0.00");
        }
        
    }
