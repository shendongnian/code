    public class OptionViewModel
    {
        [DisplayName("Option")]
        [Required]
        [DataType("DropDownList")]
        public int OptionID { get; set; }
    
        [DisplayName("Name")]
        [Required]
        public string OptionSelectionName { get; set; }
    
        public SelectList Options { get; private set; }
    
        public OptionViewModel()
        {
            Options = new SelectList(new OptionRepository().GetAll(), "ID", "Name");
        }
    
        public OptionViewModel(IOption option)
        {
            this.OptionID = option.OptionID;
            this.OptionSelectionName = option.OptionName;
            Options = new SelectList(new OptionRepository().GetAll(), "ID", "Name", OptionID);
        }
    }
