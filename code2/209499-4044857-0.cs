	public static int CountConnectedReaders(SqlConnection conn)
	{
	    int readers = 0;
	    Type t = conn.GetType();
	    MemberInfo[] minf = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
	    for (int i = 0; i < minf.Length; i++)
	    {
		if (minf[i].Name == "get_InnerConnection")
		{                    
		    MethodInfo methinf = (MethodInfo)minf[i];
		    object result = methinf.Invoke(conn, new object[0]);
		    PropertyInfo[] pinfs = result.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
		    foreach (PropertyInfo pinf in pinfs)
		    {
			if (pinf.PropertyType.Name == "DbReferenceCollection")
			{
			    object dbrc = pinf.GetValue(result, new object[0]);
			    if (dbrc == null) readers = 0;
			    else
			    {
				MemberInfo[] dbrcInfs = dbrc.GetType().GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
				foreach (MemberInfo dbrcInf in dbrcInfs)
				{
				    if (dbrcInf.Name == "_dataReaderCount")
				    {
					FieldInfo finf = (FieldInfo)dbrcInf;
					readers = (Int32) finf.GetValue(dbrc);
				    }
				}
			    }
			}
		    }
		}
	    }
	    return readers;
	}
