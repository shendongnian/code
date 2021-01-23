	// userDn is a Distinguished Name such as:
	// "LDAP://CN=Joe Smith,OU=Sales,OU=domain,OU=com"
	public ArrayList Groups(string userDn, bool recursive)
	{
		ArrayList groupMemberships = new ArrayList();
		return AttributeValuesMultiString("memberOf", userDn,
			groupMemberships, recursive);
	}
	public ArrayList AttributeValuesMultiString(string attributeName,
		 string objectDn, ArrayList valuesCollection, bool recursive)
	{
		DirectoryEntry ent = new DirectoryEntry(objectDn);
		PropertyValueCollection ValueCollection = ent.Properties[attributeName];
		IEnumerator en = ValueCollection.GetEnumerator();
		while (en.MoveNext())
		{
			if (en.Current != null)
			{
				if (!valuesCollection.Contains(en.Current.ToString()))
				{
					valuesCollection.Add(en.Current.ToString());
					if (recursive)
					{
						AttributeValuesMultiString(attributeName, "LDAP://" +
						en.Current.ToString(), valuesCollection, true);
					}
				}
			}
		}
		ent.Close();
		ent.Dispose();
		return valuesCollection;
	}
