    public class  PatientService : DataService<IPatientRepository>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
           // TODO: set rules to indicate which entity sets and service 
              operations are visible, updatable, etc.
              ...
        }
        [WebGet]
        public IQueryable<Patient> Patients()
        {
            return from p in CurrentDataSource.Patients select p;
        }
    
        protected override IPatientRepository CreateDataSource()
        {
            IUnityContainer container = new UnityContainer();
            Bootstrapper.Initialise(container);
            return container.Resolve<IPatientRepository>();
        }
    }
