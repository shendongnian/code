    public class ViewModel
    {
        private readonly List<IceCreamFlavor> _flavors;
     
        [Display(Name = "Favorite Flavor")]
        public int SelectedFlavorId { get; set; }
     
        public IEnumerable<SelectListItem> FlavorItems
        {
             get { return new SelectList(_flavors, "Id", "Name");}
        }
    }
