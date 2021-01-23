    public partial class TestClass : ITestInterface{
      bool ITestInterface.Encryption {
        set { m_Encryption = value; }
      }
      public bool EncryptionVB {
        set { ((ITestInterface)this).Encryption = value; }
      }
    }
