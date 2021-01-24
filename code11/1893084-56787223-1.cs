    using System;
    using Microsoft.SharePoint.Client;
    using System.Linq;
    using System.Net;
    
    public class SPList
    {
        private readonly ClientContext context;
        private readonly List list;
        private readonly ListItemCollection items;
        private readonly Web web;
    
        //Credentials may be needed, its commented out!
        public SPList(String siteUrl, String listName, NetworkCredential netCred)
        {
            try
            {
                //NetworkCredential _myCredentials = netCred;
                context = new ClientContext(siteUrl);
                list = context.Web.Lists.GetByTitle(listName);
                items = list.GetItems(CamlQuery.CreateAllItemsQuery());
                web = context.Web;
                context.Load(items);
                context.Load(list);
                context.Load(context.Web.Lists, lists => lists.Include(list => list.Title));
                context.ExecuteQuery();
                Console.WriteLine("Connected to SharePoint successfully!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    
        public void CreateNewItem(String userName, int employeeNumber, String fullName, String firstName, String lastName, DateTime emplymentStart, DateTime employmentEnd, String department, String mobile, String address, String postcode, String postTown, String email)
        {
            try
            {
                ListItemCreationInformation newItemSepc = new ListItemCreationInformation();
                ListItem newItem = list.AddItem(newItemSepc);
                newItem["Title"] = userName;
                newItem["Employee_x0020_Number"] = employeeNumber;
                newItem["Full_x0020_Name"] = fullName;
                newItem["First_x0020_Name"] = firstName;
                newItem["Last_x0020_Name"] = lastName;
                newItem["_x000a_Employment_x0020_start_x0"] = emplymentStart.Date;
                newItem["Employment_x0020_end_x0020_date"] = employmentEnd.Date;
                newItem["Department"] = department;
                newItem["Mobile"] = mobile;
                newItem["Adress"] = address;
                newItem["Postcode"] = postcode;
                newItem["Post_x0020_town"] = postTown;
                newItem["Email"] = email;
                newItem["Person"] = fullName;
                newItem.Update();
                context.ExecuteQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
