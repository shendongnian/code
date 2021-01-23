    public void UpdateEntityAttributeAssociations(Model model,
                                                  IEnumerable<Entity> current)
    {
        unitOfWork.Context.Entry(model).Collection(m => m.Entities).Load();
        ICollection<Entity> original = model.Entities; // perhaps .ToList() necessary
        // delete
        List<Entity> toDelete = null;
        if (original != null)
        {
            toDelete = GetToDelete(original, current);
            foreach (Entity originalEntityToDelete in toDelete)
            {
                unitOfWork.Context.Entity.Remove(originalEntityToDelete);
            }
        }
        // add, update
        if (current != null)
        {
            foreach (Entity currentEntity in current)
            {
                if (toDelete == null || !toDelete.Contains(currentEntity))
                {
                    if (original.Where(originalEntity => originalEntity.IEntity == 
                                   currentEntity.IEntity).FirstOrDefault() == null)
                    {
                        model.Entity.Add(currentEntity);
                    }
                }
            }
        }
    }
