    public class UserProfileViewModel
    {
        public UserProfileViewModel() 
        {
            AllCarriers = new AspAppServicesContext().Carriers.ToList();
            selCarrier = new SelectList(AllCarriers, "ID", "Name", null);
        }
        public UserProfileViewModel(RegisterModel profile)
        {
            this.MyProfile = profile;
            AllCarriers = new AspAppServicesContext().Carriers.ToList();
            selCarrier = new SelectList(AllCarriers, "ID", "Name", this.MyProfile.CarrierID);
        }
        public RegisterModel MyProfile { get; set; }
        public List<Carrier> AllCarriers { get; set; }
        public SelectList selCarrier { get; set; }
        public object SelectedCarrier { get; set; }
    }
