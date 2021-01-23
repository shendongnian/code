    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        int Divide(int n1, int n2);
    }
    public Calculator : ICalculator
    {
        int Divide(int n1, int n2)
        {
            try
            {
                return n1/n2;
            }
            catch (DivideByZeroException ex)
            {
                throw new FaultException<DivideByZeroException>(ex);
            }
        }
    }
