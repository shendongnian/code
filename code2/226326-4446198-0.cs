    from ca in ConsumerApplications
    join est in RepairOrderEstimates on ca.RepairOrderEstimateID == est.RepairOrderEstimateID
    join statConsumerApp in Statuses on ca.StatusID == statConsumerApp.StatusID
    join statEstimate in Statuses on est.StatusID == statEstimate.StatusID
    select new {
      ConsumerAppID = ca.ConsumerAppID,
      LastName = ca.LastName,
      AppStatus = statConsumerApp.StatusName,
      EstimateStatus = statEstimate.StatusName,
    }
