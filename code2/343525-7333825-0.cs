    WorkItemStore store = new WorkItemStore(collection);
    Changeset changeset = service.GetChangeset(123, true, true);
    
    WorkItem item = new WorkItem(project.WorkItemTypes["CustomItem"]);     
    item.Links.Add(new ExternalLink(store.RegisteredLinkTypes[ArtifactLinkIds.Changeset], changeset.ArtifactUri.AbsoluteUri));       
    item.Fields["CustomField1"].Value = someValue;
    item.Fields["CustomField2"].Value = someValue;
    item.Fields["CustomField3"].Value = someValue;
    item.Validate();
    item.Save();
