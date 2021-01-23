		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvoiceId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long InvoiceId
		{
			get
			{
				return this._InvoiceId;
			}
			set
			{
				if ((this._InvoiceId != value))
				{
					this.OnInvoiceIdChanging(value);
					this.SendPropertyChanging();
					this._InvoiceId = value;
					this.SendPropertyChanged("InvoiceId");
					this.OnInvoiceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvoiceNum", DbType="VarChar(15)")]
		public string InvoiceNum
		{
			get
			{
				return this._InvoiceNum;
			}
			set
			{
				if ((this._InvoiceNum != value))
				{
					this.OnInvoiceNumChanging(value);
					this.SendPropertyChanging();
					this._InvoiceNum = value;
					this.SendPropertyChanged("InvoiceNum");
					this.OnInvoiceNumChanged();
				}
			}
		}
