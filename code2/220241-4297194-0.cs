    public class HomeIndexViewModel
    {
        // A SelectList containing elements for the DropDownLists in the Home "Index" view.
        public SelectList problemAreas1 { get; set; }
        public SelectList problemAreas2 { get; set; }
        public SelectList problemAreas3 { get; set; }
    
        // Items chosen in the DropDownLists.
        public string itemOne { get; set; }
        public string itemTwo { get; set; }
        public string itemThree { get; set; }
    
        // String for IDing what button is pressed.
        public string submitButton { get; set; }
    }
