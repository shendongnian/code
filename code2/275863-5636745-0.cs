    public partial class DataClasses
    {		
        partial void OnCreated()
		{
			Connection.ConnectionString = SQLHelpers.GetConnectionStr();
		}
    }
