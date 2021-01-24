    		    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
				//service.Credentials = new NetworkCredential( "{Active Directory ID}", "{Password}", "{Domain Name}" );
				service.AutodiscoverUrl("First.Last@MyCompany.com");
				FolderId FolderToAccess = new FolderId(WellKnownFolderName.Inbox, "First.Last@MyCompany.com");
				FindItemsResults<Item> findResults = service.FindItems(
				   FolderToAccess,
				   new ItemView(10)
				);
				foreach (Item item in findResults.Items)
				{
					Console.WriteLine(item.Subject);
				}
