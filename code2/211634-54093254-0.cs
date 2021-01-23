    public class DevconHelper
    {
        private readonly ILogger logger;
        public DevconHelper(ILogger logger)
        {
            this.logger = logger;
        }
    
        readonly static string devconPath = @"devcon\" + (Environment.Is64BitOperatingSystem ? "x64" : "x86") + @"\devcon.exe";
        readonly static Regex parseHwidsOutput = new Regex(@"(?<id>[^\n]+)\n {4}Name: (?<name>[^\n]+)\n {4}Hardware IDs:\n(?<hwids>(?: {8}[^\n]+\n?)+)");
        readonly static Regex parseEnableDisableOutput = new Regex(@"(\d+) device\(s\) (are enabled|disabled)\.");
            
        public async Task<IEnumerable<Device>> GetDevicesAsync(string filterString = "*")
        {
            logger.Trace("GetDevicesAsync");
            using (var listDevicesProcess = Process.Start(new ProcessStartInfo(devconPath, "hwids " + filterString) { RedirectStandardOutput = true, UseShellExecute = false }))
            {
                var content = await listDevicesProcess.StandardOutput.ReadToEndAsync();
                    
                var matches = parseHwidsOutput.Matches(content.Replace(Environment.NewLine, "\n")); //Regex is based on \n
                logger.Trace("GetDevicesAsync process output: {Content}, parsed {NumberOfMatches}, devconPath: {DevconPath}", content, matches.Count, devconPath);
                return matches.OfType<Match>().Select(match =>
                {
                    var id = match.Groups["id"].Value;
                    var name = match.Groups["name"].Value;
                    var hwids = match.Groups["hwids"].Value.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim());
                    return new Device() { Id = id, Name = name, HardwareIds = hwids.ToArray() };
                });
            }
        }
    
        public async Task<bool> EnableAsync(Device device)
        {
            logger.Trace("EnableAsync");
            using (var disableProcess = Process.Start(new ProcessStartInfo(devconPath, "enable " + device.HardwareIds.First()) { RedirectStandardOutput = true, UseShellExecute = false }))
            {
                var content = await disableProcess.StandardOutput.ReadToEndAsync();
                var lastLine = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last();
                logger.Trace("EnableAsync process output: {Content}, LastLine: {LastLine}", content, lastLine);
                return parseEnableDisableOutput.IsMatch(lastLine);
            }
        }
    
        public async Task<bool> DisableAsync(Device device)
        {
            logger.Trace("DisableAsync");
            using (var disableProcess = Process.Start(new ProcessStartInfo(devconPath, "disable " + device.HardwareIds.First()) { RedirectStandardOutput = true, UseShellExecute = false }))
            {
                var content = await disableProcess.StandardOutput.ReadToEndAsync();
                var lastLine = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last();
                logger.Trace("DisableAsync process output: {Content}, LastLine: {LastLine}", content, lastLine);
                return parseEnableDisableOutput.IsMatch(lastLine);
            }
        }
    
        public class Device
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string[] HardwareIds { get; set; }
        }
    }
