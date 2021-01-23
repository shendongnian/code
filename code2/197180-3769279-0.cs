    [ServiceContract]
    [ServiceKnownType(typeof(Dog))]
    public interface IService
    {
        [OperationContract]
        void BringPet(Pet pet);
    
        [OperationContract]
        void TakePet(Pet pet);
    
        [OperationContract]
        List<Pet> GetAllPets();
    }
