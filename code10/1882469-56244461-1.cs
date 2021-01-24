    IEnumerableM<Note> notesApprovedByUser = notes
        .Where(note => note.Approver == GetADDetails.displayName 
                    || note.Approver == GetADDetails.userName);
    IEnumerable<string> submitters = notesApprovedByUser
        .Select(note => note.SubmittedBy);
    List<string> submitterList = submitters.ToList();
    IEnumerable<string> distinctSubmitters = submitterList.Distinct();
