    bool bIsPersonnel = false;
    
    if(_Assignments.HasFlag(AssignmentType.Attendant) ||
        _Assignments.HasFlag(AssignmentType.ConductorCBS) ||
        _Assignments.HasFlag(AssignmentType.ReaderCBS) ||
        _Assignments.HasFlag(AssignmentType.Chairman) ||
        _Assignments.HasFlag(AssignmentType.Mike) ||
        _Assignments.HasFlag(AssignmentType.PlatformAttendant) ||
        _Assignments.HasFlag(AssignmentType.Prayer) ||
        _Assignments.HasFlag(AssignmentType.OCLM) ||
        _Assignments.HasFlag(AssignmentType.Sound) ||
        _Assignments.HasFlag(AssignmentType.Custom) )
    {
        bIsPersonnel = true;
    }
