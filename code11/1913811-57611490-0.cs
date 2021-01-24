		private DataTable ConvertListToDataTable(List<ParticipantClass> participants){
			DataTable table = new DataTable();
			table.Columns.Add("ID");
			table.Columns.Add("FirstName");
			table.Columns.Add("LastName");
			var maxTimeLaps = 0;
			foreach (var p in participants) {
				// Create the row's data.
				List<Object> array = new List<Object> { p.ID, p.FirstName, p.LastName };
				array.AddRange(p.LapTimes.Cast<Object>());
				
				// Add additional columns for larger sets of TimeLaps.
				if (maxTimeLaps < p.LapTimes.Count) {
					for (int i = maxTimeLaps; i < p.LapTimes.Count; i++) {
						table.Columns.Add(i.ToString());
					}
					maxTimeLaps = p.LapTimes.Count;
				}
				
				// Add new row to table.
				table.Rows.Add(array.ToArray());
			}
			return table;
		}
