    ClientContext clientContext = new ClientContext("http://sp2013/sites/team");
    Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle("Customers");
    clientContext.Load(spList);
    clientContext.ExecuteQuery();
    
    if (spList != null && spList.ItemCount > 0)
    {
    	Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
    	camlQuery.ViewXml = @"<View>
    							<Query> 
    								<Where><Eq><FieldRef Name='CustomerRef' />
    									<Value Type='Number'>1121</Value></Eq>
    								</Where> 
    							</Query> 
    							<ViewFields><FieldRef Name='CustomerRef' /></ViewFields> 
    						</View>";
    	ListItemCollection listItems = spList.GetItems(camlQuery);
    	clientContext.Load(listItems);
    	clientContext.ExecuteQuery();
    	Console.WriteLine(listItems.Count);
    }
