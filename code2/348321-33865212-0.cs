     C# CLASS FILES
			public class url_details
			{
				public string url;
				public string page_name;
				public string icon;
			}
						
			C# inside login page			
			List<url_details> url_list = new List<url_details>();            
            foreach (DataRow dr in dataTable.Rows)
            {
                url_details url_item = new url_details();
                url_item.url = dr["url"].ToString();
                url_item.page_name = dr["page_name"].ToString();
                url_item.icon = dr["icon"].ToString();
                url_list.Add(url_item);
            }			
			Session["urls"] = url_list;
						
			
			C#-HTML MENU FORM
			 <%
                var uruls = (List<url_details>)Session["urls"];
                foreach (var url in uruls)
                {%>
					<li><a href="..<%=url.url %>"><%=url.icon %><span><%=url.page_name %></span></a></li>
				<% }                
                
			%>
