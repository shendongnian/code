    @code
    {
        private bool visible;
        [Parameter]
        public bool PopupVisible
        {
            get { return visible }
            set
            {
                if (visible != value)
                {
                    visible = value;
           
                }
            }
        } 
    
       [Parameter] public EventCallback<bool> PopupVisibleChanged { get; set; }
       // Invoke the EventCallback to update the parent component' private field visible with the new value.
      
       private Task UpdatePopupVisible()
        {
            PopupVisible = false;
            return PopupVisibleChanged.InvokeAsync(PopupVisible);
        }
    }
