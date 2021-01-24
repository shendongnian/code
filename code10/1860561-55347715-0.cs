        public void button7_Click(object sender, EventArgs e)
        {
            DataTable dt6 = new DataTable();
            dt6.Columns.Add("Name");
            dt6.Columns.Add("Position");
            DataRow row;
            
            var doc = new HtmlWeb().Load("https://www.numberfire.com/nba/daily-fantasy/daily-basketball-projections");
            foreach (HtmlNode node1 in doc.DocumentNode.SelectNodes("//span[@class='player-info']"))
            {
                row = dt6.NewRow();
                foreach (HtmlNode node in node1.SelectNodes(".//a"))
                {
                    row["Name"] = node.InnerHtml.Trim();
                }
                    foreach (HtmlNode node2 in node1.SelectNodes(".//span[@class='player-info--position']"))
                    {
                        row["Position"] = node2.InnerText.Trim();
                     
                    }
                dt6.Rows.Add(row);
            }
            dataGridView4.DataSource = dt6;
            }
