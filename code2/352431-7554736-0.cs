    try
		{
			object o = Convert.ChangeType(row["Input"], Type.GetType(row["DataType"]));
		}
		catch (Exception ex)
		{
			
			// Its not a type
		}
