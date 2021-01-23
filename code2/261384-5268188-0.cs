    public class LicenseViewModel
    {
      public IEnumerable<SelectListItem> LicensedState { get; private set; }
      public IEnumerable<SelectListItem> LicenseType { get; private set; }
      public LicenseViewModel(string licensedState = null, string licenseType = null)
      {
        LicensedState = LicensedStatesProvider.All().Select(s=> new SelectListItem
          {Selected = licensedState!= null && s == licensedState, Text = s, Value = s} );
        LicenseType = LicenseTypesProvider.All().Select(t => new SelectListItem
          { Selected = licenseType != null && t == licenseType, Text = t, Value = t });
      }
    }
LicensedStatesProvider and LicenseTypesProvider are simply way of getting all LicensedStates and LicenseTypes, it's up to you how to get them.
 
