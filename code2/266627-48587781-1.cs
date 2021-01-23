	namespace System
	{
		public static class DALSqlExtension
		{
			public static void AplicaTransaction(this SqlDataAdapter _adapter, SqlTransaction transaction)
			{
				if (_adapter == null)
				{
					return;
				}
				if (_adapter.InsertCommand != null)
				{
					_adapter.InsertCommand.Transaction = transaction;
					_adapter.InsertCommand.Connection = transaction.Connection;
				}
				if (_adapter.UpdateCommand != null)
				{
					_adapter.UpdateCommand.Transaction = transaction;
					_adapter.UpdateCommand.Connection = transaction.Connection;
				}
				if (_adapter.DeleteCommand != null)
				{
					_adapter.DeleteCommand.Transaction = transaction;
					_adapter.DeleteCommand.Connection = transaction.Connection;
				}
				if (_adapter.SelectCommand != null)
				{
					_adapter.SelectCommand.Transaction = transaction;
					_adapter.SelectCommand.Connection = transaction.Connection;
				}
			}
		}
	}
