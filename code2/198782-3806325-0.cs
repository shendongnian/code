    Regex degrees = new Regex(
                    @"(?<degrees>\d+)(?:-(?<minutes>\d+))?(?:-(?<seconds>\d+))?");
    string[] samples = new []{ "123", "123-456", "123-456-789" };
    foreach (var sample in samples)
    {
        Match m = degrees.Match(sample);
        if(m.Success)
        {
            string degrees = m.Groups["degrees"].Value;
            string minutes = m.Groups["minutes"].Value;
            string seconds = m.Groups["seconds"].Value;
            Console.WriteLine("{0}°{1}'{2}\"", degrees,
                String.IsNullOrEmpty(minutes) ? "0" : minutes,
                String.IsNullOrEmpty(seconds) ? "0" : seconds
            );
        }
    }
