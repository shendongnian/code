	public class RegistrationViewModel
	{
		public IList<LicenseViewModel> Licenses { get; set; }
	}
	public class LicenseViewModel
	{
		public string LicensedState { get; set; }
		public string LicenseType { get; set; }
		
		public IEnumerable<LicenseState> LicenseStates { get; set; }
		public IEnumerable<LicenseType> LicenseTypes { get; set; }
	}
