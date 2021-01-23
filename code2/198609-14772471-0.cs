        var Content = File.ReadAllText(SlnPath);
        Regex projReg = new Regex(
            "Project\\(\"\\{[\\w-]*\\}\"\\) = \"([\\w _]*)\", \"(.*\\.(cs|vcx|vb)proj)\""
            , RegexOptions.Compiled);
        var matches = projReg.Matches(Content).Cast<Match>();
        var Projects = matches.Select(x => x.Groups[2].Value).ToList();
        //Projects = Projects.Select(x => EnvironmentOps.ExpandEnvVariableInPath(x)).ToList();
        for (int i = 0; i < Projects.Count; ++i)
        {
            if (!System.IO.Path.IsPathRooted(Projects[i]))
                Projects[i] = Path.Combine(Path.GetDirectoryName(SlnPath),
                    Projects[i]);
            Projects[i] = Path.GetFullPath(Projects[i]);
        }
