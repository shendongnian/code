    bool bIsPersonnel = false;
    
    if(_Assignments.HasFlag(AssignmentType.Attendant | AssignmentType.ConductorCBS |
        AssignmentType.ReaderCBS | AssignmentType.Chairman |
        AssignmentType.Mike | AssignmentType.PlatformAttendant |
        AssignmentType.Prayer | AssignmentType.OCLM |
        AssignmentType.Sound | AssignmentType.Custom))
    {
        bIsPersonnel = true;
    }
