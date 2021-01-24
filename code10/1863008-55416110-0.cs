`
         var clinicalAssets = from s in db.ClinicalAssets
                                  join cp in db.ClinicalPATs on s.ClinicalAssetID equals cp.ClinicalAssetID into AP
                                  from subpat in AP.DefaultIfEmpty()
                                  select new ClinicalASSPATVM
                                  {
                                   ClinicalAssetID = s.ClinicalAssetID,
                                   ProductName = s.ProductName,
                                   InspectionDocumnets = subpat.InspectionDocumnets ?? String.Empty };
`
