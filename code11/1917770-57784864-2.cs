    bool AreEqualAccordingToMyRules(string input1, string input2)
    {
        var split1 = input1.Split('/');
        var split2 = input2.Split('/');
        return split1.Length == split2.Length  // strings must have equal number of sections
           && split1[0] == split2[0] // section 1 must match
           && split1[1] == split2[1] // section 2 must match
           && split1[3] == split2[3] // section 4 must match
    }
