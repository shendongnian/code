     if (list.ContentTypes.Count > 0)
                    {
    
                        SPContentType ct = list.ContentTypes[0]; //Specify the content type here, if you have more than one content type in your list.
    
                        string[] fieldnames = { "ContentType", "Title", "Course", "CourseLocation",  "EventDate", "EndDate", "Description", "fAllDayEvent", "fRecurrence", "WorkspaceLink", "EventType", "UID", "RecurrenceID", "EventCanceled", "Duration", "RecurrenceData", "TimeZone", "XMLTZone", "MasterSeriesItemID", "Workspace", "Location"};
                        ct.FieldLinks.Reorder(fieldnames);
                        web.AllowUnsafeUpdates = true;
                        ct.Update(true);
                        web.AllowUnsafeUpdates = false;
                    }
