    public void Update(ViewModel returnedViewModel)
    {
        // Gets the orininal Model from DataBase.
        DatabaseModel originalRecord = _unitOfWork.DatabaseModel.Get(id);
        // Merge original model with the ViewModel   
        originalRecord = _mapper.Map<ViewModel, DatabaseModel>(mappedModel, originalRecord);
        // SaveChanges
        _unitOfWork.DatabaseModel.Update(originalRecord);
    }
