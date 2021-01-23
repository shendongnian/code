        [ServiceContract]
        [ServiceKnownType(typeof(Atm))]
        [ServiceKnownType(typeof(List<Atm>))]
        public interface IAtmFinderService
        {
    
            [OperationContract]
            ICollection<IAtm> GetAtms();
    
        }
