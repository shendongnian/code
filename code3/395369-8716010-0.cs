    var patientSpec = patientSearch.BuildPatientSpecification();
    var admissionSpec = patientSearch.BuildAdmissionSpecification();
    _patientSearchResultModel = _patientRepository.Where(patientSpec)
        .SelectMany(p=>p.Admissions).Where(admissionSpec)
        .Select(a=> new {
            PatientId = a.Patient.Id,
            AdminssionId = a.Id,
            a.PhaseType,
            a.Patient.Last,
            a.Patient.First,
            a.InPatientLocation,
            a.AdmissionDate,
            a.DischargeDate,
            a.RRI,
            a.CompletionStatus,
            a.FollowupStatus
        }).AsEnumerable()
        .Select(x=> new PatientSearchResultModel(x.PatientId, x.AdmissionId ...))
        .ToList();
