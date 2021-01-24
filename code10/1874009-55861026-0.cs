public void Post(MyViewModel inputModel)
{
    var id = inputModel.Id;
    var dbModel = GetById(id);
    dbModel.Field1 = inputModel.Field1;
    dbModel.Field2 = inputModel.Field2;
    dbModel.Field3 = inputModel.Field3;
    dbModel.Field4 = inputModel.Field4;
    UpdateModelInDB(dbModel);
}
