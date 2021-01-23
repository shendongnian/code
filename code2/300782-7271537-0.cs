    public ActionResult UpdateEntity(MyEntity newEntity)
    {
        var existingEntity = GetFromRepository(newEntity.Id);
        bool keyFieldsHaveChanged = UpdateExistingEntity(newEntity, existingEntity);
        if (keyFieldsHaveChanged)
        {
            ThreadPool.QueueUserWorkItem(o =>
                                            {
                                                GenerateEmails();
                                                GenerateReports();
                                            });
            
        }
        return Json(SuccessMessage);
    }
