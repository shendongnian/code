    var pupils = adminDataProvider.GetPupilsBySchoolclassId(s.SchoolclassId);
    s.Pupils.AddRange(pupils);
    foreach (Pupil p in pupils)
    {
       var documents = adminDataProvider.GetDocumentsByPupilId(p.Id);
       p.Documents.AddRange(documents);
    }
