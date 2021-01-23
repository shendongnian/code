            DataTable personsTable = new DataTable("Person");
			personsTable.Columns.Add("Id", typeof(int));
			personsTable.Columns.Add("Name", typeof(string));
			personsTable.Columns.Add("Age", typeof(int));
			foreach (var item in collection)
			{
				DataRow row = personsTable.NewRow();
				row["Id"] = item.Id;
				row["Name"] = item.Name;
				row["Age"] = item.Age;
				personsTable.Rows.Add(row);
				if (item.ObjectState == DataObjectState.Added)
				{
					continue;
				}
				row.AcceptChanges();
				if (item.ObjectState == DataObjectState.Deleted)
				{					
					row.Delete();
				}
				else if (item.ObjectState == DataObjectState.Modified)
				{
					row.BeginEdit();
					row.EndEdit();
				}
			}
