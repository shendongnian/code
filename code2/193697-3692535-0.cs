	public bool EncryptionVB {
		set { m_Encryption = value; }
	}
	bool ITestInterface.Encryption {
		set { EncryptionVB = value; }
	}
