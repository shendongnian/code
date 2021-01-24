public void InsertOrUpdate(PartAttribute model)
{
  var existingRecord = dbContext.Set<PartAttribute>().Find(model.attributeId);
  if(existingRecord == null)
  { // Insert (Should not include value for attributeId)
     dbContext.Add(model);
  }
  else
  { // Update
    existingRecord = model;
    dbContext.SaveChanges();
  }
}
Please let me know if you still have issues
