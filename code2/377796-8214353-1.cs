    public class CustomGridView : GridView
    {
        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
        	int numRows = base.CreateChildControls(dataSource, dataBinding);
        	//no data rows created, create empty table
        	if (numRows == 0)
        	{
        		//create table
        		Table table = new Table();
        		table.ID = this.ID;
        
        		//create a new header row
        		GridViewRow row = base.CreateRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
        
        		//convert the exisiting columns into an array and initialize
        		DataControlField[] fields = new DataControlField[this.Columns.Count];
        		this.Columns.CopyTo(fields, 0);
        		this.InitializeRow(row, fields);
        		row.TableSection = TableRowSection.TableHeader;
        		table.Rows.Add(row);
        		this.Controls.Add(table);
        	}
        	return numRows;
        }
    }
