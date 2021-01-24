    public static List<LocationViewModel> GetHierarchy(List<LinkParentChildViewModel> linkParentChildViewModels, int parentId)
    {
        return linkParentChildViewModels.Where(x => x.Parent.Id == parentId).Select(x => new LocationViewModel
        {
            Id = x.Parent.Id,
            Code = x.Parent.Code,
            ChildLocations = GetHierarchy(linkParentChildViewModels, x.Child.ChildLocationId)
        }).ToList();
    }
