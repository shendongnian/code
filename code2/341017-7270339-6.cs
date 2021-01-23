    // Fetch the original domain model we want to update
    var domainModel = _service.Get(viewModel.Id);
    
    // Update only the properties that are present on the view:
    Mapper.Map<UpdateViewModel, DomainViewModel>(viewModel, domainModel);
    
    // Pass to the service layer for processing:
    string error;
    if (!_service.Update(domainModel, out error))
    {
        ...
    }
