    using System;
    using Microsoft.Exchange.WebServices.Data;
    using System.Net;
    
    namespace ExchangePublicFolders {
        class Program {
            static FolderId FindPublicFolder (ExchangeService myService, FolderId baseFolderId,
                string folderName) {
    
                // We will search using paging. We will use page size 10
                FolderView folderView = new FolderView (10,0);
                folderView.OffsetBasePoint = OffsetBasePoint.Beginning;
                // we will need only DisplayName and Id of every folder
                // se we'll reduce the property set to the properties
                folderView.PropertySet = new PropertySet (FolderSchema.DisplayName,
                    FolderSchema.Id);
    
                FindFoldersResults folderResults;
                do {
                    folderResults = myService.FindFolders (baseFolderId, folderView);
    
                    foreach (Folder folder in folderResults)
                        if (String.Compare (folder.DisplayName, folderName, StringComparison.OrdinalIgnoreCase) == 0)
                            return folder.Id;
    
                    if (folderResults.NextPageOffset.HasValue)
                        // go to the next page
                        folderView.Offset = folderResults.NextPageOffset.Value;
                }
                while (folderResults.MoreAvailable);
    
                return null;
            }
    
            static void MyTest () {
                // IMPORTANT: ExchangeService is NOT thread safe, so one should create an instance of
                // ExchangeService whenever one needs it.
                ExchangeService myService = new ExchangeService (ExchangeVersion.Exchange2007_SP1);
    
                myService.Credentials = new NetworkCredential ("MyUser@corp.local", "myPassword00");
                myService.Url = new Uri ("http://mailwebsvc-t.services.local/ews/exchange.asmx");
                // next line is very practical during development phase or for debugging
                myService.TraceEnabled = true;
    
                Folder myPublicFoldersRoot = Folder.Bind (myService, WellKnownFolderName.PublicFoldersRoot);
                string myPublicFolderPath = @"OK soft GmbH (DE)\Gruppenpostfächer\_Template - Gruppenpostfach\_Template - Kalender";
                string[] folderPath = myPublicFolderPath.Split('\\');
                FolderId fId = myPublicFoldersRoot.Id;
                foreach (string subFolderName in folderPath) {
                    fId = FindPublicFolder (myService, fId, subFolderName);
                    if (fId == null) {
                        Console.WriteLine ("ERROR: Can't find public folder {0}", myPublicFolderPath);
                        return;
                    }
                }
    
                // verify that we found 
                Folder folderFound = Folder.Bind (myService, fId);
                if (String.Compare (folderFound.FolderClass, "IPF.Appointment", StringComparison.Ordinal) != 0) {
                    Console.WriteLine ("ERROR: Public folder {0} is not a Calendar", myPublicFolderPath);
                    return;
                }
    
                CalendarFolder myPublicFolder = CalendarFolder.Bind (myService,
                    //WellKnownFolderName.Calendar,
                    fId,
                    PropertySet.FirstClassProperties);
    
                if (myPublicFolder.TotalCount == 0) {
                    Console.WriteLine ("Warning: Public folder {0} has no appointment. We try to create one.", myPublicFolderPath);
    
                    Appointment app = new Appointment (myService);
                    app.Subject = "Writing a code example";
                    app.Start = new DateTime (2010, 9, 9);
                    app.End = new DateTime (2010, 9, 10);
                    app.RequiredAttendees.Add ("oleg.kiriljuk@ok-soft-gmbh.com");
                    app.Culture = "de-DE";
                    app.Save (myPublicFolder.Id, SendInvitationsMode.SendToNone);
                }
    
                // We will search using paging. We will use page size 10
                ItemView viewCalendar = new ItemView (10);
                // we can include all properties which we need in the view
                // If we comment the next line then ALL properties will be
                // read from the server. We can see there in the debug output
                viewCalendar.PropertySet = new PropertySet (ItemSchema.Subject);
                viewCalendar.Offset = 0;
                viewCalendar.OffsetBasePoint = OffsetBasePoint.Beginning;
                viewCalendar.OrderBy.Add (ContactSchema.DateTimeCreated, SortDirection.Descending);
    
                FindItemsResults<Item> findResultsCalendar;
                do {
                    findResultsCalendar = myPublicFolder.FindItems (viewCalendar);
    
                    foreach (Item item in findResultsCalendar) {
                        if (item is Appointment) {
                            Appointment appoint = item as Appointment;
                            Console.WriteLine ("Subject: \"{0}\"", appoint.Subject);
                        }
                    }
    
                    if (findResultsCalendar.NextPageOffset.HasValue)
                        // go to the next page
                        viewCalendar.Offset = findResultsCalendar.NextPageOffset.Value;
                }
                while (findResultsCalendar.MoreAvailable);
            }
            static void Main (string[] args) {
                MyTest();
            }
        }
    }
