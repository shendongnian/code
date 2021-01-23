    using System.Text.RegularExpressions;
    ...
    command = Regex.Replace(command, @"\s*#.*$", "");
    if (command != "")
    {
        // this is a command, not a comment line
        // and any comment has been stripped off
    }
