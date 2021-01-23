    public partial class TestClass : ITestInterface
    {
        public bool EncryptionVB
        {
             ((ITestInterface)this).Encryption = value;
        }
    
        bool ITestInterface.Encryption { set; }
    }
