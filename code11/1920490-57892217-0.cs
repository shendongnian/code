    public class Rootobject
    {
        public string id { get; set; }
        public long vehiculeId { get; set; }
        public int companyId { get; set; }
        public string phoneNumber { get; set; }
        public long hardwareId { get; set; }
        public int gpsBoxType { get; set; }
        public string name { get; set; }
        public int iconId { get; set; }
        public int gpsBoxTrackingDelay { get; set; }
        public bool rowEnabled { get; set; }
        public long dbInsertTime { get; set; }
        public Device device { get; set; }
        public Vehiculegpsboxinfo vehiculeGpsBoxInfo { get; set; }
        public Fleetdetail[] fleetDetail { get; set; }
    }
    public class Device
    {
        public string id { get; set; }
        public long imei { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public Registration registration { get; set; }
    }
    public class Registration
    {
        public string id { get; set; }
        public long imei { get; set; }
        public int companyId { get; set; }
        public long latestRegistrationStatusChangeDate { get; set; }
        public int registrationStatus { get; set; }
        public Imeinavigation imeiNavigation { get; set; }
    }
    public class Imeinavigation
    {
        public string _ref { get; set; }
    }
    public class Vehiculegpsboxinfo
    {
        public string id { get; set; }
        public long vehiculeId { get; set; }
        public int currentDelay { get; set; }
        public int normalTrackingMode { get; set; }
        public int timeModeDelay { get; set; }
        public int smartModeDelay { get; set; }
        public int smartModeDistance { get; set; }
        public bool connected { get; set; }
        public int heartBeatPeriod { get; set; }
        public bool insureCoherence { get; set; }
        public bool killHedgehog { get; set; }
        public long lastCommunicationTime { get; set; }
        public int vehiculeConfiguration { get; set; }
        public int updateStatus { get; set; }
        public Vehicule vehicule { get; set; }
        public Vehiculeconfigurationnavigation vehiculeConfigurationNavigation { get; set; }
    }
    public class Vehicule
    {
        public string _ref { get; set; }
    }
    public class Vehiculeconfigurationnavigation
    {
        public string id { get; set; }
        public int configurationId { get; set; }
        public string configName { get; set; }
        public string masterName { get; set; }
        public string master { get; set; }
        public string firmware { get; set; }
        public string system { get; set; }
        public int gpsBoxType { get; set; }
        public object[] vehiculeGpsBoxInfoBoardConfigurationNavigation { get; set; }
        public Vehiculegpsboxinfovehiculeconfigurationnavigation[] vehiculeGpsBoxInfoVehiculeConfigurationNavigation { get; set; }
    }
    public class Vehiculegpsboxinfovehiculeconfigurationnavigation
    {
        public string _ref { get; set; }
    }
    public class Fleetdetail
    {
        public string id { get; set; }
        public int fleetDetailId { get; set; }
        public int fleetId { get; set; }
        public long vehiculeId { get; set; }
        public bool rowEnabled { get; set; }
        public Fleet fleet { get; set; }
        public Vehicule7 vehicule { get; set; }
    }
    public class Fleet
    {
        public string id { get; set; }
        public int fleetId { get; set; }
        public int companyId { get; set; }
        public string name { get; set; }
        public bool rowEnabled { get; set; }
        public Fleetdetailfleet[] fleetDetailFleet { get; set; }
        public object[] fleetDetailFleetChildNavigation { get; set; }
    }
    public class Fleetdetailfleet
    {
        public string id { get; set; }
        public int fleetDetailId { get; set; }
        public int fleetId { get; set; }
        public long vehiculeId { get; set; }
        public bool rowEnabled { get; set; }
        public Fleet1 fleet { get; set; }
        public Vehicule1 vehicule { get; set; }
        public string _ref { get; set; }
    }
    public class Fleet1
    {
        public string _ref { get; set; }
    }
    public class Vehicule1
    {
        public string id { get; set; }
        public long vehiculeId { get; set; }
        public int companyId { get; set; }
        public string phoneNumber { get; set; }
        public long hardwareId { get; set; }
        public int gpsBoxType { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public int iconId { get; set; }
        public int gpsBoxTrackingDelay { get; set; }
        public int addressProtocol { get; set; }
        public bool rowEnabled { get; set; }
        public long dbInsertTime { get; set; }
        public Device1 device { get; set; }
        public Vehiculegpsboxinfo1 vehiculeGpsBoxInfo { get; set; }
        public Fleetdetail2[] fleetDetail { get; set; }
    }
    public class Device1
    {
        public string id { get; set; }
        public long imei { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public Registration1 registration { get; set; }
    }
    public class Registration1
    {
        public string id { get; set; }
        public long imei { get; set; }
        public int companyId { get; set; }
        public long latestRegistrationStatusChangeDate { get; set; }
        public int registrationStatus { get; set; }
        public Imeinavigation1 imeiNavigation { get; set; }
    }
    public class Imeinavigation1
    {
        public string _ref { get; set; }
    }
    public class Vehiculegpsboxinfo1
    {
        public string id { get; set; }
        public long vehiculeId { get; set; }
        public int currentDelay { get; set; }
        public int normalTrackingMode { get; set; }
        public int timeModeDelay { get; set; }
        public int smartModeDelay { get; set; }
        public int smartModeDistance { get; set; }
        public bool connected { get; set; }
        public int heartBeatPeriod { get; set; }
        public bool insureCoherence { get; set; }
        public bool killHedgehog { get; set; }
        public bool boardConnected { get; set; }
        public long lastCommunicationTime { get; set; }
        public long boardLastCommunicationTime { get; set; }
        public int vehiculeConfiguration { get; set; }
        public int updateStatus { get; set; }
        public Vehicule2 vehicule { get; set; }
        public Vehiculeconfigurationnavigation1 vehiculeConfigurationNavigation { get; set; }
    }
    public class Vehicule2
    {
        public string _ref { get; set; }
    }
    public class Vehiculeconfigurationnavigation1
    {
        public string id { get; set; }
        public int configurationId { get; set; }
        public string configName { get; set; }
        public string masterName { get; set; }
        public string master { get; set; }
        public string firmware { get; set; }
        public string system { get; set; }
        public int gpsBoxType { get; set; }
        public object[] vehiculeGpsBoxInfoBoardConfigurationNavigation { get; set; }
        public Vehiculegpsboxinfovehiculeconfigurationnavigation1[] vehiculeGpsBoxInfoVehiculeConfigurationNavigation { get; set; }
    }
    public class Vehiculegpsboxinfovehiculeconfigurationnavigation1
    {
        public string _ref { get; set; }
        public string id { get; set; }
        public long vehiculeId { get; set; }
        public int currentDelay { get; set; }
        public int normalTrackingMode { get; set; }
        public int timeModeDelay { get; set; }
        public int smartModeDelay { get; set; }
        public int smartModeDistance { get; set; }
        public bool connected { get; set; }
        public int heartBeatPeriod { get; set; }
        public bool insureCoherence { get; set; }
        public bool killHedgehog { get; set; }
        public long lastCommunicationTime { get; set; }
        public int vehiculeConfiguration { get; set; }
        public int updateStatus { get; set; }
        public long lastConnexionTime { get; set; }
        public Vehicule3 vehicule { get; set; }
        public Vehiculeconfigurationnavigation2 vehiculeConfigurationNavigation { get; set; }
    }
    public class Vehicule3
    {
        public string id { get; set; }
        public long vehiculeId { get; set; }
        public int companyId { get; set; }
        public string phoneNumber { get; set; }
        public long hardwareId { get; set; }
        public int gpsBoxType { get; set; }
        public string name { get; set; }
        public int iconId { get; set; }
        public int gpsBoxTrackingDelay { get; set; }
        public int addressProtocol { get; set; }
        public bool rowEnabled { get; set; }
        public long dbInsertTime { get; set; }
        public Device2 device { get; set; }
        public Vehiculegpsboxinfo2 vehiculeGpsBoxInfo { get; set; }
        public Fleetdetail1[] fleetDetail { get; set; }
    }
    public class Device2
    {
        public string id { get; set; }
        public long imei { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public Registration2 registration { get; set; }
    }
    public class Registration2
    {
        public string id { get; set; }
        public long imei { get; set; }
        public int companyId { get; set; }
        public long latestRegistrationStatusChangeDate { get; set; }
        public int registrationStatus { get; set; }
        public Imeinavigation2 imeiNavigation { get; set; }
    }
    public class Imeinavigation2
    {
        public string _ref { get; set; }
    }
    public class Vehiculegpsboxinfo2
    {
        public string _ref { get; set; }
    }
    public class Fleetdetail1
    {
        public string id { get; set; }
        public int fleetDetailId { get; set; }
        public int fleetId { get; set; }
        public long vehiculeId { get; set; }
        public bool rowEnabled { get; set; }
        public Fleet2 fleet { get; set; }
        public Vehicule5 vehicule { get; set; }
    }
    public class Fleet2
    {
        public string id { get; set; }
        public int fleetId { get; set; }
        public int companyId { get; set; }
        public string name { get; set; }
        public bool rowEnabled { get; set; }
        public Fleetdetailfleet1[] fleetDetailFleet { get; set; }
        public object[] fleetDetailFleetChildNavigation { get; set; }
    }
    public class Fleetdetailfleet1
    {
        public string id { get; set; }
        public int fleetDetailId { get; set; }
        public int fleetId { get; set; }
        public long vehiculeId { get; set; }
        public bool rowEnabled { get; set; }
        public Fleet3 fleet { get; set; }
        public Vehicule4 vehicule { get; set; }
        public string _ref { get; set; }
    }
    public class Fleet3
    {
        public string _ref { get; set; }
    }
    public class Vehicule4
    {
        public string _ref { get; set; }
    }
    public class Vehicule5
    {
        public string _ref { get; set; }
    }
    public class Vehiculeconfigurationnavigation2
    {
        public string _ref { get; set; }
    }
    public class Fleetdetail2
    {
        public string id { get; set; }
        public int fleetDetailId { get; set; }
        public int fleetId { get; set; }
        public long vehiculeId { get; set; }
        public bool rowEnabled { get; set; }
        public Fleet4 fleet { get; set; }
        public Vehicule6 vehicule { get; set; }
        public string _ref { get; set; }
    }
    public class Fleet4
    {
        public string id { get; set; }
        public int fleetId { get; set; }
        public int companyId { get; set; }
        public string name { get; set; }
        public bool rowEnabled { get; set; }
        public Fleetdetailfleet2[] fleetDetailFleet { get; set; }
        public object[] fleetDetailFleetChildNavigation { get; set; }
        public string _ref { get; set; }
    }
    public class Fleetdetailfleet2
    {
        public string _ref { get; set; }
    }
    public class Vehicule6
    {
        public string _ref { get; set; }
    }
    public class Vehicule7
    {
        public string _ref { get; set; }
    }
