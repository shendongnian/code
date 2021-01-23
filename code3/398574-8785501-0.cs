     while (myreader.Read())
               {
                   if (myreader["subid"] != null)
                   {
                       string str = string.Format("<div>{0}</div>",myreader["subid"]);
                       container.Controls.Add(new LiteralControl(str)); //literal we added in markup
                   }
           }
