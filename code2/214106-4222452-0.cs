		private void GetParameters()
		{
			//DataTable dt = new DataTable("Params");
			string dataTableName  = "Params";
			//add a tablestyle to the grid so there will be custom columnstyles available
			// after the datasource has been set....
			DataGridTableStyle ts = new System.Windows.Forms.DataGridTableStyle();
			ts.MappingName = dataTableName;
			dtgParams.TableStyles.Add(ts);
			// DataGridTextBoxColumn
			DataGridTextBoxColumn cParamName = new DataGridTextBoxColumn();
			cParamName.MappingName = "Parameter";
			cParamName.HeaderText = "Parameter";
			cParamName.ReadOnly=true;
			// Add the column style to the column style collection
			ts.GridColumnStyles.Add( cParamName );
			// DataGridTextBoxColumn
			DataGridTextBoxColumn cType = new DataGridTextBoxColumn();
			cType.MappingName = "Data_Type";
			cType.HeaderText = "Data Type";
			cType.ReadOnly=true;
			// Add the column style to the column style collection
			ts.GridColumnStyles.Add( cType );
			// DataGridTextBoxColumn
			DataGridTextBoxColumn cValue = new DataGridTextBoxColumn();
			cValue.MappingName = "Value";
			cValue.HeaderText = "Value";
			cValue.ReadOnly=false;
			// Add the column style to the column style collection
			ts.GridColumnStyles.Add( cValue );
			DataRow dr;
			dt.Columns.Add(new DataColumn("Parameter",typeof(string)));
			dt.Columns.Add(new DataColumn("Data_Type",typeof(string)));
			dt.Columns.Add(new DataColumn("Value",typeof(string)));
			// For all the Parameters defined in the report
			for(int i=0;i<ReportDoc.DataDefinition.ParameterFields.Count;  i++)
			{
				dr = dt.NewRow();
				dr[0] = ReportDoc.DataDefinition.ParameterFields[i].ParameterFieldName;
				dr[1] = ReportDoc.DataDefinition.ParameterFields[i].ParameterValueKind;
				dr[2] = ReportDoc.DataDefinition.ParameterFields[i].DefaultValues[0];
				dt.Rows.Add(dr);
			}
			DataView source = new DataView(dt);
			dtgParams.DataSource = source;
		}
