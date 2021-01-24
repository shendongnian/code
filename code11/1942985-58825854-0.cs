        [System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		[XmlElement("DataSource")] // Optionally change the element name to be <DataSource>
		public string EncryptedDataSource { get; set; }
		
		[XmlIgnore]
		public string DataSource
		{
			set => EncryptedDataSource = Encryption.SimpleEncryptWithPassword(value, GlobalConstants.EncryptionPassword);
			get => Encryption.SimpleDecryptWithPassword(EncryptedDataSource, GlobalConstants.EncryptionPassword);
		}
    Demo fiddle #1 [here](https://dotnetfiddle.net/6i6AH8).
