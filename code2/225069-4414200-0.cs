    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        int Divide(int n1, int n2);
    }
