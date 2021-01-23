    [ServiceContract]
    public interface ITest {
        [OperationContract] Person[] GetAllPeople();
        [OperationContract] void DoSomething(Person person);
    }
