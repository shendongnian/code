    var stateStrings = new[] { "Investigation",
                                "Awaiting Customer",
                                "State 5",
                                "State 6",
                                "State 7",
                                "State 8",
                                "State 9",
                                "State 10",
                                "State 11",
                                "Rejected",
                                "Blocked",
                                "Postponed" };
    var stateMaxLen = stateStrings.Max(s => s.Length);
    var stateMapString = String.Join("", stateStrings.Select(s => s.PadRight(stateMaxLen)));
