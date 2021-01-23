    var AddUpdateQuery = from newdist in newSpec.Distributions
                             join oldDist in oSpec.Distributions
                             on newdist.Id equals oldDist.Id into matchingDistributions
                             select new { newdist, matchingDistributions };
        
        foreach (var dist in AddUpdateQuery)
        {
            if (!dist.matchingDistributions.Any())
            {
                dist.newdist.operation = "Add";
                //additional processing for "Add" operation.
            }
            else if (dist.newdist.Amount == dist.matchingDistributions.First().Amount)
            {
                dist.newdist.operation = "Update";
                //additional processing for "Update" operation.
            }
        }
