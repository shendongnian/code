    WorkItem workItem = workItemStore.GetWorkItem(1000);  
                 
    LinkCollection links = workItem.Links;
    List<int> relatedWorkItemIds = new List<int>();
    foreach (var link in links)
    {
       relatedWorkItemIds.Add(((Microsoft.TeamFoundation.WorkItemTracking.Client.RelatedLink) (link)).RelatedWorkItemId);
    }
    
    if(relatedWorkItemIds.Contains(1001))
    {
       return;
    }
    else
    {
       WorkItemLinkTypeEnd linkTypeEnd = workItemStore.WorkItemLinkTypes.LinkTypeEnds["Child"]; 
       RelatedLink newLink = new RelatedLink(linkTypeEnd, 1001);
       workItem.Links.Add(newLink);
    }
