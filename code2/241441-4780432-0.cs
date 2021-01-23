    SPSite mySite = SPContext.Current.Site;  
    SPWeb myWeb = SPContext.Current.Web;  
    SPList myList = myWeb.Lists["Custom List"];  
    SPListItem myListItem = myList.Items.Add(); 
    myListItem["Title"] = oTextTitle.Text.ToString();  
    myListItem["Employee Name"] = oTextName.Text.ToString();  
    myListItem["Designation"] = oTextDesignation.Text.ToString();
