    public class ProductViewModel
    {
        public string SelectedVoltage { get; set; }
        public IEnumerable<SelectListItem> Voltages 
        {
            get
            {
                return new SelectList(new[] {
                    new SelectListItem { Value = "110", Text = "110V" },
                    new SelectListItem { Value = "220", Text = "220V" },
                }, "Value", "Text");
            }
        }
        public string SelectedEquipementType { get; set; }
        public IEnumerable<SelectListItem> EquipementTypes
        {
            get
            {
                return new SelectList(new[] 
                {
                    new SelectListItem { Value = "t1", Text = "Equipement type 1" },
                    new SelectListItem { Value = "t2", Text = "Equipement type 2" },
                }, "Value", "Text");
            }
        }
        public string Word { get; set; }
    }
