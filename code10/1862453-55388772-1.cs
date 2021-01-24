    from s in db.ClinicalAssets
    join cp in db.ClinicalPATs on s.ClinicalAssetID equals cp.ClinicalAssetID
    select new ClinicalASSPATVM
    {
        ClinicalAssetID = cp.ClinicalAssetID,
        InspectionDocumnets = cp.InspectionDocumnets
    }
