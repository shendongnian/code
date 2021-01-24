        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt5 = new DataTable();
            dt5.Columns.Add("Team");
            dt5.Columns.Add("Name");
            dt5.Columns.Add("Position");
            dt5.Columns.Add("Injury");
            dt5.Columns.Add("Status");
            var doc = new HtmlWeb().Load("https://www.cbssports.com/nba/injuries/");
            
            var products = doc.DocumentNode.SelectNodes("//*[@id='TableBase']");
            
            foreach (HtmlNode product  in products)
            {
                DataRow row = dt5.NewRow();
                var teamName = product.SelectNodes(".//span[@class='TeamLogoNameLockup-name']");
                var playerName = product.SelectNodes(".//span[@class='CellPlayerName--long']");
                foreach (HtmlNode T in teamName)
                {
                    
                    row["Team"] = (Regex.Replace(T.InnerText, @"\r\n", "").Replace(" ",""));
                    dt5.Rows.Add(row);
                }
                
               
                foreach(HtmlNode P in  playerName)
                {
                    
                    row["Name"] = (Regex.Replace(P.InnerText, @"\r\n?|\n| ", ""));
                   
                    Console.WriteLine(Regex.Replace(P.InnerText, @"\r\n?|\n| ", ""));
                }
                var position = product.SelectNodes(".//td[2][contains(@class, 'TableBase-bodyTd')]");
            
                    foreach (HtmlNode Pos in position)
                    {
                   
                    row["Position"] = (Regex.Replace(Pos.InnerText, @"\r\n?|\n| ", ""));
                            
                        
                    }
                var injury = product.SelectNodes(".//td[4][contains(@class, 'TableBase-bodyTd')]");
                foreach (HtmlNode inj in injury)
                {
                    
                    row["Injury"] = (Regex.Replace(inj.InnerText, @"\r\n?|\n| ", ""));
                    
                }
                var status = product.SelectNodes(".//td[5][contains(@class, 'TableBase-bodyTd')]");
                foreach (HtmlNode stat in status)
                   
                {
                    
                    row["Status"] = (Regex.Replace(stat.InnerText, @"\r\n?|\n| ", ""));
             
                 
               
                }
    
            }
   
            dataGridView3.DataSource = dt5;
     
            }
