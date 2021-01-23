	foreach (GridViewRow tt in GridView1.Rows)
			{
				if (tt.RowType == DataControlRowType.DataRow)
				{                    
				  tt.FindControl("ddlCalculateGrid");
				}
			}
