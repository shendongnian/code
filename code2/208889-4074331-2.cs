    private void GenericUpdateEntityCollection<T>(EntityCollection<T> collection, ObjectContext dbContext)
                where T : EntityObject, new()
            {
                int count = collection.Count();
                int current = 0;
                List<T> collectionItemList = collection.ToList();
                bool isAdded = false;
                while (current < count)
                {
                    Object obj = null;
                    // Essai de récupéré l'objet dans le context pour le mettre à jour
                    dbContext.TryGetObjectByKey(collectionItemList[current].EntityKey, out obj);
                    if (obj == null)
                    {
                        // Si l'objet n'existe pas, on en créer un nouveau
                        obj = new TimeSlotEntity();
                        // On lui donne l'entity Key du nouvelle objet
                        ((T)obj).EntityKey = collectionItemList[current].EntityKey;
                        // On l'ajoute au context, dans le timeslot
                        dbContext.AddObject(((T)obj).EntityKey.EntitySetName, obj);
                        // On récupère l'objet du context qui à le même entity key que le nouveau recu en pramètre, le but est d'avoir un context d'attacher
                        dbContext.TryGetObjectByKey(collectionItemList[current].EntityKey, out obj);
                        // On change l'état de l'objet dans le context pour modifier, car 
                        dbContext.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);
                        // On change l'état de l'objet passé en paramètre pour qu'il soit au même state que celui dans le context
                        collection.CreateSourceQuery().Context.ObjectStateManager.ChangeObjectState(collectionItemList[current], System.Data.EntityState.Modified);
                        // On place notre flag pour dire que nous avons ajouter dans le context les donnée
                        isAdded = true;
                    }
    
                    if (obj != null)
                    {
                        // On applique les changements de l'objet passé en parametre à celui dans le context
                        dbContext.ApplyCurrentValues<T>(((T)obj).EntityKey.EntitySetName,collectionItemList[current]);
                        // On replace les state des deux objet, celui dans le context et celui passé en parametre à added pour la sauvegarde.
                        if (isAdded)
                        {
                            dbContext.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Added);
                            collection.CreateSourceQuery().Context.ObjectStateManager.ChangeObjectState(collectionItemList[current], System.Data.EntityState.Added);
                        }
                    }
                    current++;
                }
            }
