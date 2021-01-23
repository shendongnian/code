      private void Heading_Load(object sender, System.EventArgs e)
    {
    	InsertNodes(null, 0);
    }
    private void InsertNodes(TreeNode n, int hdrID)
    {
    	System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Acounting;Integrated Security=True;Pooling=False");
    	con.Open();
    	SqlCommand cmd = new SqlCommand("SELECT hdrid,title FROM [Heading] WHERE ParentID=" + hdrID, con);
    	SqlDataReader rdr = cmd.ExecuteReader();
    	while (rdr.Read()) {
    		TreeNode t = new TreeNode(rdr("title").ToString());
    		InsertNodes(t, Convert.ToInt16(rdr("hdrID").ToString()));
    		if (n == null) {
    			trvHeader.Nodes.Add(t);
    		} else {
    			n.Nodes.Add(t);
    		}
    	}
    	rdr.Close();
             }
