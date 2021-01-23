     for (int i=0; i<objects.Count; i++) 
     {        
        DataModelObject dmo = (DataModelObject)objects.GetAt(i);
        if (!sl.ContainsKey(dmo.Guid))
        {
            sl.Add(dmo.Guid, dmo);
        }
     }
