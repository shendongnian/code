          ClientContext clientContext = new ClientContext("https://example.com/sites/testsite/");  
          clientContext.Credentials = new NetworkCredential("user", "password", "domain");
                // Get the SharePoint web  
                Web web = clientContext.Web;  
                  
                // Get the SharePoint list collection for the web  
                ListCollection listColl = web.Lists;  
                  
                // Retrieve the list collection properties  
                clientContext.Load(listColl);  
      
                // Execute the query to the server.  
                clientContext.ExecuteQuery();  
                  
                // Loop through all the list  
                foreach (List list in listColl)  
                {  
                    // Display the list title and ID  
                    Console.WriteLine("List Name: " + list.Title + "; ID: " + list.Id);  
                }  
                Console.ReadLine();
