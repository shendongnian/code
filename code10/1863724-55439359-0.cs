    var valid = AssignmentType.Student | AssignmentType.Assistant | AssignmentType.Demonstration;
    var invalid = ~valid; // Everything that isn't valid
    if (_Assignments & invalid != 0)
    {
        // There was at least one invalid flag
    }
