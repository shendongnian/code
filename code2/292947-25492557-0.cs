    List<Entities.InformationRequestOrderLink> links = adjustmentContext.InformationRequestOrderLinks
    .Where(item => item.OrderNumber == irOrderLinkVO.OrderNumber && item.InformationRequestId == irOrderLinkVO.InformationRequestId).ToList();
    int id = 0;
    if (links.Any())
    {
      id = links.Max(x => x.Id);
     }
    if (id == 0)
    {
    //do something here
    }
