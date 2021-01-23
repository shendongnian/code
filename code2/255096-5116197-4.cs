    string path = "M5.4,3.806h6.336v43.276h20.738v5.256H5.4V3.806z";
    string separators = @"(?=[MZLHVCSQTAmzlhvcsqta])"; // these letters are valid SVG
                                 // commands. Whenever we find one, a new command is 
                                 // starting. Let's split the string there.
    var tokens = Regex.Split(path, separators).Where(t => !string.IsNullOrEmpty(t));
