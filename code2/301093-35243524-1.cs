    <ServiceContract()>
    <XmlSerializerFormat()>
    Public Interface IService    
        <OperationContract()>
        <WebMethod()>
        Function CreateLoan(ByVal LoanRequest As LoanAccount) As String
    End Interface
    //C# Class
    public class LoanAccount
    {
        [XmlElement]
        public string New { get; set; }
        [XmlElement]
        public String CustomerNo { get; set; }
        [XmlElement]
        public string AcctType { get; set; }
	}
