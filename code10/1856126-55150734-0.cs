     public static void Process() {
        DataTable dt5 = new DataTable();
        dt5.Columns.Add("Team");
        dt5.Columns.Add("Name");
        dt5.Columns.Add("Position");
        dt5.Columns.Add("Injury");
        dt5.Columns.Add("Status");
        var doc = new HtmlWeb().Load("https://www.cbssports.com/nba/injuries/daily/");
        DataRow row;
            var tables = doc.DocumentNode.SelectNodes("//*[@id='TableBase']/div/div/table");
            foreach (HtmlAgilityPack.HtmlNode node in tables) {
                var rows = node.SelectNodes("//tr");
                foreach (HtmlAgilityPack.HtmlNode node2 in rows) {
                    row = dt5.NewRow();
                    var tdNodes = node2.DescendantNodes().Where(o => o.Name == "td");
                    if (tdNodes.Any()) {
                        row["Team"] = Regex.Replace(tdNodes.ElementAt(0).InnerText, @"\r\n?|\n| ", "");
                        row["Name"] = Regex.Replace(tdNodes.ElementAt(1).InnerText, @"\r\n?|\n| ", "");
                        row["Position"] = Regex.Replace(tdNodes.ElementAt(2).InnerText, @"\r\n?|\n| ", "");
                        row["Injury"] = Regex.Replace(tdNodes.ElementAt(3).InnerText, @"\r\n?|\n| ", "");
                        row["Status"] = Regex.Replace(tdNodes.ElementAt(4).InnerText, @"\r\n?|\n| ", "");
                        dt5.Rows.Add(row);
                    }
                }
            }
 
            foreach(DataRow item in dt5.Rows) {
                Console.WriteLine(item.ItemArray[0] + " " + item.ItemArray[1]);
            }
        }
