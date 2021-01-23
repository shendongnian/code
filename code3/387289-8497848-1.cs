            Entity target = (Entity)context.InputParameters["Target"];
            // Récupération des lignes de contrat liées au contrat courant
            FetchExpression fetch = new FetchExpression(@"
                <fetch distinct='false' mapping='logical'>
                  <entity name='new_contrats'>
                    <link-entity name='new_lignecontrat' alias='nombreligne' from='new_contratsid' to='new_contratsid'>
                    </link-entity>
                  </entity>
                </fetch>");
            // Note: Do you need some attribute fields so that the entities are actually returning some relevant data
            // Note: Do you want to retrieve ALL the 'new_contrats' or should you be adding a condition in here to the primary entity?
            //  <filter type='and'>
            //    <condition attribute='MyIdFieldHere' operator='eq' value='" + context.PrimaryEntityId + "' /> 
            //  </filter>
            EntityCollection lines = service.RetrieveMultiple(fetch);
            // Vérification qu'il y a au moins une ligne de contrat associée
            if (lines.Entities.Any())
            {
                // store last entity in variable so that the collection is enumerabled 4 seperate times
                var last = lines.Entities.Last();
                if (last.GetAttributeValue<OptionSetValue>("statecode").Value == 1)
                {
                    if (last.GetAttributeValue<float>("new_unitesrestantes") < 0)
                    {
                        var unitesRestantes = (target.GetAttributeValue<float>("new_unitesrestantes")) + (last.GetAttributeValue<float>("new_unitesrestantes"));
                        var unitesUtilisee = (target.GetAttributeValue<float>("new_unitesutilisees")) - (last.GetAttributeValue<float>("new_unitesutilisees"));
                        target["new_unitesutilisees"] = unitesUtilisee;
                        target["new_unitesrestantes"] = unitesRestantes;
                    }
                }
            }
            else
            {
                // if 'new_unitesutilisees' is a float, then the value must also be a float
                target["new_unitesutilisees"] = 0f; 
                target["new_unitesrestantes"] = target["new_unitestotales"];
            }     
