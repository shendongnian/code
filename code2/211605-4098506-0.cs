    public partial class WebForm1 : System.Web.UI.Page
    {
    	private List<string> CurrentTestData
    	{
    		get
    		{
    			if (ViewState["CurrentTestData"] == null)
    				return new List<string>();
    			else
    				return (List<string>)ViewState["CurrentTestData"];
    		}
    		set
    		{
    			ViewState["CurrentTestData"] = value;
    		}
    	}
    
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!Page.IsPostBack)
    		{
    			CurrentTestData = getTestData();
    			GenerateTable(CurrentTestData);
    		}
    		else
    			GenerateTable(CurrentTestData);
    	}
    
    	private List<string> getTestData()
    	{
    		List<string> tData = new List<string>();
    		Random rand = new Random();
    		for (int i = 0; i < 10; i++)
    		{
    			tData.Add("proc" + (CurrentTestData.Count + i) + "_" + rand.Next(100) + "_" + rand.Next(100));
    		}
    
    		return tData;
    	}
    
    	protected void btnClear_Click(object sender, EventArgs e)
    	{
    		ClearTheTable();
    		CurrentTestData = null;
    	}
    
    	protected void btnLoad_Click(object sender, EventArgs e)
    	{
    		var CombinedTestData = CurrentTestData;
    		CombinedTestData.AddRange(getTestData());
    		CurrentTestData = CombinedTestData;
    		GenerateTable(CurrentTestData);
    	}
    
    	protected void btnKill_Click(object sender, EventArgs e)
    	{
    		lblMsg.Text = "You pressed button " + ((Button)sender).Text;
    	}
    
    	private void GenerateTable(List<string> list)
    	{
    		ClearTheTable();
    
    		int st = 0;
    		foreach (string line in list)
    		{
    			TableRow tr = new TableRow();
    			Processes.Controls.Add(tr);
    
    			foreach (String str in line.Split('_'))
    			{
    				int index = tr.Cells.Add(new TableCell());
    				tr.Cells[index].Text = str;
    			}
    
    			Button b = new Button();
    			b.Text = "Kill " + st;
    			b.ID = "btnKill_" + st;
    			b.Click += new EventHandler(btnKill_Click);
    			TableCell tc = new TableCell();
    			tc.Controls.Add(b);
    			tr.Cells.Add(tc);
    
    			tr.TableSection = TableRowSection.TableBody;
    			st++;
    		}
    		Processes.BorderStyle = BorderStyle.Solid;
    		Processes.GridLines = GridLines.Both;
    		Processes.BorderWidth = 2;
    	}
    
    	private void ClearTheTable()
    	{
    		for (int i = Processes.Rows.Count; i > 1; i--)
    		{
    			Processes.Rows.RemoveAt(i - 1);
    		}
    	}
    }
