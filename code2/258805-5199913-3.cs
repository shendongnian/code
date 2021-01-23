    var byPatient = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, InstanceInformation>>>>();
    foreach (var patientGroup in instances.GroupBy(x => x.PatientID))
    {
        var byStudy = new Dictionary<string, Dictionary<string, Dictionary<string, InstanceInformation>>>();
        byPatient.Add(patientGroup.Key, byStudy);
        foreach (var studyGroup in patientGroup.GroupBy(x => x.StudyID))
        {
            var bySeries = new Dictionary<string, Dictionary<string, InstanceInformation>>();
            byStudy.Add(studyGroup.Key, bySeries);
            foreach (var seriesIdGroup in studyGroup.GroupBy(x => x.SeriesID))
            {
                var byInstance = new Dictionary<string, InstanceInformation>();
                bySeries.Add(seriesIdGroup.Key, byInstance);
                foreach (var inst in seriesIdGroup)
                {
                    byInstance.Add(inst.InstanceID, inst);
                }
            }
        }
    }
