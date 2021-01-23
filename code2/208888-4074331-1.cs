    public ExpertEntity SaveExpert(SaveExpertArgs args)
            {
    
                string connString = ConfigurationManager.ConnectionStrings["CalendarContainer"].ConnectionString;
                using (CalendarContainer dbContext = new CalendarContainer(connString))
                {
                    ExpertEntity expert = (from e in dbContext.ExpertEntities
                                           where e.ExpertIdentifier == args.Expert.ExpertIdentifier
                                           select e).FirstOrDefault();
                    if (expert == null)
                    {
                        args.Expert.ExpertIdentifier = Guid.NewGuid();
                        dbContext.AddToExpertEntities(args.Expert);
                    }
                    else
                    {
                        dbContext.ExpertEntities.ApplyCurrentValues(args.Expert);
                        UpdateTimeSlot(args.Expert.TimeSlotEntities, dbContext);
                    }
                    dbContext.SaveChanges();
                    return args.Expert;
                }
            }
    
            private void UpdateTimeSlot(EntityCollection<TimeSlotEntity> timesSlot, CalendarContainer dbContext)
            {
    
                int count = timesSlot.Count();
                int current = 0;
                List<TimeSlotEntity> timeSlotList = timesSlot.ToList();
                bool isAdded = false;
                while (current < count)
                {
                    Object obj = null;
                    // Essai de récupéré l'objet dans le context pour le mettre à jour
                    dbContext.TryGetObjectByKey(timeSlotList[current].EntityKey, out obj);
                    if (obj == null)
                    {
                        // Si l'objet n'existe pas, on en créer un nouveau
                        obj = new TimeSlotEntity();
                        // On lui donne l'entity Key du nouvelle objet
                        ((TimeSlotEntity)obj).EntityKey = timeSlotList[current].EntityKey;
                        // On l'ajoute au context, dans le timeslot
                        dbContext.AddToTimeSlotEntities(obj as TimeSlotEntity);
                        // On récupère l'objet du context qui à le même entity key que le nouveau recu en pramètre, le but est d'avoir un context d'attacher
                        dbContext.TryGetObjectByKey(timeSlotList[current].EntityKey, out obj);
                        // On change l'état de l'objet dans le context pour modifier, car 
                        dbContext.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);
                        // On change l'état de l'objet passé en paramètre pour qu'il soit au même state que celui dans le context
                        timesSlot.CreateSourceQuery().Context.ObjectStateManager.ChangeObjectState(timeSlotList[current], System.Data.EntityState.Modified);
                        // On place notre flag pour dire que nous avons ajouter dans le context les donnée
                        isAdded = true;
                    }
    
                    if (obj != null)
                    {
                        // On applique les changements de l'objet passé en parametre à celui dans le context
                        dbContext.TimeSlotEntities.ApplyCurrentValues(timeSlotList[current]);
                        // On replace les state des deux objet, celui dans le context et celui passé en parametre à added pour la sauvegarde.
                        if (isAdded)
                        {
                            dbContext.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Added);
                            timesSlot.CreateSourceQuery().Context.ObjectStateManager.ChangeObjectState(timeSlotList[current], System.Data.EntityState.Added);
                        }
                    }
                    current++;
                }
            }
