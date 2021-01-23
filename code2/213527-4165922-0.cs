    [Serializable,  
    DataContract]  
    public class MainBusinessLine : BaseDataContract  
    {  
        Int32 _MainBusinessLineID;
        [Key,
        DataMember,
        Required]
        public Int32 MainBusinessLineID
        {
            get
            {
                return _MainBusinessLineID;
            }
            set
            {
                if (_MainBusinessLineID == value)
                    return;
                _MainBusinessLineID = value;
                ReportPropertyChanged("MainBusinessLineID");
            }
        }
  
        ObservableCollection<GroupsReference> _GroupsReferenceCollection;
        [DataMember,
        Include,
        Association("GroupsReferenceCollection", "MainBusinessLineID", "MainBusinessLineID")]
        public ObservableCollection<GroupsReference> GroupsReferenceCollection
        {
            get
            {
                return _GroupsReferenceCollection;
            }
            set
            {
                _GroupsReferenceCollection = value;
                ReportPropertyChanged("GroupsReferenceCollection");
            }
        }
    }
  
    [Serializable,  
    DataContract]  
    public class GroupsReference : BaseDataContract
    {
        Int32 _GroupsReferenceID;
        [Key,
        DataMember,
        Required]
        public Int32 GroupsReferenceID
        {
            get
            {
                return _GroupsReferenceID;
            }
            set
            {
                if (_GroupsReferenceID == value)
                    return;
                _GroupsReferenceID = value;
                ReportPropertyChanged("GroupsReferenceID");
            }
        }
  
        Int32 _MainBusinessLineID;
        [DataMember,
        Required]
        public Int32 MainBusinessLineID
        {
            get
            {
                return _MainBusinessLineID;
            }
            set
            {
                if (_MainBusinessLineID == value)
                    return;
                _MainBusinessLineID = value;
                ReportPropertyChanged("MainBusinessLineID");
            }
        }
  
        Int32 _GroupID;
        [DataMember,
        Required]
        public Int32 GroupID
        {
            get
            {
                return _GroupID;
            }
            set
            {
                if (_GroupID == value)
                    return;
                _GroupID = value;
                ReportPropertyChanged("GroupID");
            }
        }
    }  
  
    [Serializable,  
    DataContract]  
    public class Group : BaseDataContract  
    {  
        Int32 _GroupID;
        [Key,
        DataMember,
        Required]
        public Int32 GroupID
        {
            get
            {
                return _GroupID;
            }
            set
            {
                if (_GroupID == value)
                    return;
                _GroupID = value;
                ReportPropertyChanged("GroupID");
            }
        }
  
        ObservableCollection<GroupsReference> _GroupsReferenceCollection;
        [DataMember,
        Include,
        Association("GroupsReferenceCollection", "GroupID", "GroupID")]
        public ObservableCollection<GroupsReference> GroupsReferenceCollection
        {
            get
            {
                return _GroupsReferenceCollection;
            }
            set
            {
                _GroupsReferenceCollection = value;
                ReportPropertyChanged("GroupsReferenceCollection");
            }
        }
    }  
  
    [EnableClientAccess(RequiresSecureEndpoint = false)]
    public class DentalAdminPortalDomainService : DomainService
    {
        
        public DentalAdminPortalDomainService()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        }
        [Query]
        public IQueryable<MainBusinessLine> GetMainBusinessLines()
        {
            return DataRepository.GetMainBusinessLines().AsQueryable<MainBusinessLine>();
        }
  
        [Query]
        public IQueryable<Groups> GetGroups()
        {
            return DataRepository.GetGroups().AsQueryable<Groups>();
        }
  
        [Query]
        public IQueryable<GroupLOBList> GetGroupsReference()
        {
            return DataRepository.GetGroupsReferences().AsQueryable<GroupsReference>();
        }  
    }  
  
