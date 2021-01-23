                Microsoft.Office.Interop.Outlook._Application objOutlook; //declare Outlook application
                objOutlook = new Microsoft.Office.Interop.Outlook.Application(); //create it
                Microsoft.Office.Interop.Outlook._NameSpace objNS = objOutlook.Session; //create new session
                Microsoft.Office.Interop.Outlook.MAPIFolder oAllPublicFolders; //what it says on the tin
                Microsoft.Office.Interop.Outlook.MAPIFolder oPublicFolders; // as above
                Microsoft.Office.Interop.Outlook.MAPIFolder objContacts; //as above
                Microsoft.Office.Interop.Outlook.Items itmsFiltered; //the filtered items list
                oPublicFolders = objNS.Folders["Public Folders"];
                oAllPublicFolders = oPublicFolders.Folders["All Public Folders"];
                objContacts = oAllPublicFolders.Folders["Global Contacts"];
                itmsFiltered = objContacts.Items.Restrict(strFilter);//restrict the search to our filter terms
