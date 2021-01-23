    SELECT MonitoringJob.ID
    ,      MonitoringJob.CreationDate
    ,      MonitoringJob.LastCheck
    ,      MonitoringJob.Category
    ,      MonitoringJob.URL
    ,      MonitoringJob.Description
    ,      MonitoringJob.IsJobActive
    ,      MAX(History.ChangeDateTime)
    FROM  MonitoringJob
    INNER JOIN History
    ON MonitoringJob.ID=History.JobID
    GROUP BY MonitoringJob.URL
          ,  MonitoringJob.ID
          ,  MonitoringJob.CreationDate
          ,  MonitoringJob.LastCheck
          ,  MonitoringJob.Category    
          ,  MonitoringJob.Description
          ,  MonitoringJob.IsJobActive
