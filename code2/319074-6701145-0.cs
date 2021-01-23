    public class WidgetViewModel
    {    
        [Required]
        public string Name { get; set; }
    
        [Required]
        public WidgetType WidgetTypeId { get; set; }
    
        public SelectList WidgetTypes 
        {
            get
            {
                 //This should be popuplated in your controller or factory not in the view model
                 retun new SelectList{ _repository.GetWidgets(),"Id","Name");
    
            }
       }
    }
