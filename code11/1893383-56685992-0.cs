    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.KanbanDatabase))
                {
                    DataTable dat = new DataTable();
                    dat.Columns.AddRange(new DataColumn[13] { new DataColumn("O_Date"), new DataColumn("O_User"), new DataColumn("O_Material"), new DataColumn("O_Description"), new DataColumn("O_Sloc"), new DataColumn("O_Supplier"), new DataColumn("O_StandardPack"), new DataColumn("O_KanbanSize"), new DataColumn("O_Qty"), new DataColumn("Entry Date"), new DataColumn("PO"), new DataColumn("O_Urgency"), new DataColumn("Quantity") });
                    StringBuilder _sqlQuery = new StringBuilder("SELECT Kanban_Order.[O_Date], Kanban_Order.[O_User], Kanban_Order.[O_Material], Kanban_Order.[O_Description], Kanban_Order.[O_Sloc], Kanban_Order.[O_Supplier], Kanban_Order.[O_StandardPack], Kanban_Order.[O_KanbanSize], Kanban_Order.[O_Qty], Kanban_GR101.[Entry Date], Kanban_GR101.[PO], Kanban_Order.[O_Urgency], Kanban_GR101.[Quantity]");
    				_sqlQuery.Append(" FROM Kanban_Order, Kanban_GR101");
    				_sqlQuery.Append($" WHERE Kanban_Order.[O_Material] = Kanban_GR101.[Material] AND O_Date BETWEEN {dateFrom} AND  {dateTo}");
                    using (SqlCommand cmd = new SqlCommand(_sqlQuery.ToString() , conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        conn.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds,dat);
                        Status1.DataSource = dat;
                        Status1.DataBind();
