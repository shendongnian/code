    var rejectedTypes = new[] { DocumentType.FlashNotes, DocumentType.CallMeetingNotes,
                                DocumentType.OtherNotes, DocumentType.TearSheet }.Cast<int>();
    var accessLevel = IoC.Resolve<IClientAuthorizationService>()
                         .Authorize("Put", "ManageDocuments")
    doc.canView = ((accessLevel == AuthAccessLevel.Full) &&
                   !rejectedTypes.Contains(i.DOCUMENT_TYPE_ID));
