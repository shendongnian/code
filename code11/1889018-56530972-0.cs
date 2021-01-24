    public class DeviceUnderTestViewModel
	{    
		public int pkDeviceUnderTest { get; set; }
        [Required]
        public string nkDeviceUnderTest { get; set; }
        [Required]
        public string nkNotes { get; set; }
		
        public int HardwareId { get; set; } //pkHardware
        public IEnumerable<SelectListItem> HardwareSelectList { get; set; } //dropdown of Hardware
	}
