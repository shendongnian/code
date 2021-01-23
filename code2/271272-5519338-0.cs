    public class InsertBuilder
	{
		public InsertBuilder()
		{
		}
		public InsertBuilder(string tableName, string[] columns, object[] values)
		{
			this.tableName = tableName;
			this.columns = columns;
			this.values = values;
		}
		private string tableName;
		public string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}
		private string[] columns;
		public string[] Columns
		{
			get { return columns; }
			set { columns = value; }
		}
		private object[] values;
		public object[] Values
		{
			get { return values; }
			set { values = value; }
		}
		public string InsertString
		{
			get
			{
				return CreateInsertString();
			}
		}
		public void Clear()
		{
			this.values = null;
			this.columns = null;
			this.tableName = null;
		}
		private string CreateInsertString()
		{
			if(columns.Length == 0) 
				throw new InvalidOperationException(
					"Columns must contain atleast one column"
					);
			if(values.Length == 0) 
				throw new InvalidOperationException(
					"Values must contain atleast one value"
					);
			if(columns.Length != values.Length)
			{
				throw new InvalidOperationException(
					string.Format(
						"Columns length {0} does not match Values length {1}",
						columns.Length,
						values.Length)
						);
			}
			StringBuilder insertString = new StringBuilder();
			insertString.Append(CreateTableStatement());
			insertString.Append(CreateColumnsStatement());
			insertString.Append(CreateValuesStatement());
			return insertString.ToString();
		}
		private string CreateTableStatement()
		{
			return " INSERT INTO " + tableName;
		}
		private string CreateColumnsStatement()
		{
			StringBuilder columnsStatement = new StringBuilder();
			columnsStatement.Append("(");
			for(int i = 0;i < columnsStatement.Length;i++)
			{
				columnsStatement.Append(columnsStatement[i]);
				if(i < values.Length - 1) { columnsStatement.Append(","); }
			}
			columnsStatement.Append(")");
			return columnsStatement.ToString();
		}
		private string CreateValuesStatement()
		{
			StringBuilder valuesStatement = new StringBuilder();
			valuesStatement.Append("VALUES");
			valuesStatement.Append("(");
			for(int i = 0;i < values.Length;i++)
			{
				valuesStatement.Append("@" + values[i].ToString());
				if(i < values.Length - 1) { valuesStatement.Append(","); }
			}
			valuesStatement.Append(")");
			return valuesStatement.ToString();
		}
	}
