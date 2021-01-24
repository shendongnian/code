    internal sealed class CustomFileTarget : NLog.Targets.FileTarget
    {
        private const int _maxOldFilesToKeep = 10;
        private readonly string _directory;
        private readonly long _fileMaxSize = (long)10.Megabytes().Bytes;
        private readonly string _fileNamePrefix;
        private int _sequential;
        private string FullFileName => $"{Path.Combine(_directory, _fileNamePrefix)}.{_sequential}.log";
        public CustomFileTarget(string directory, string fileNamePrefix)
        {
            _directory = directory;
            _fileNamePrefix = fileNamePrefix;
            _sequential = GetLatestSequence() ?? 0;
            ConcurrentWrites = false;
            FileName = FullFileName;
            KeepFileOpen = false;
        }
        protected override void Write(IList<AsyncLogEventInfo> logEvents)
        {
            base.Write(logEvents);
            if (GetFileSize() >= _fileMaxSize)
            {
                ChangeName();
                DeleteOld();
            }
        }
        private long GetFileSize() =>
            new FileInfo(FullFileName).Length;
        private void ChangeName()
        {
            _sequential++;
            FileName = FullFileName;
            LogManager.ReconfigExistingLoggers();
        }
        private void DeleteOld()
        {
            var fileNamesAndSequences = GetFileNamesAndSequences();
            if (fileNamesAndSequences.Count() > _maxOldFilesToKeep + 1)
            {
                fileNamesAndSequences.Take(
                    fileNamesAndSequences.Count() - _maxOldFilesToKeep + 1)
                    .ForEach(
                        _ => Directory.Delete(Path.Combine(_directory, _.FileName)));
            }
        }
        private int? GetLatestSequence()
        {
            var fileNamesAndSequences = GetFileNamesAndSequences();
            return fileNamesAndSequences.Any()
                ? fileNamesAndSequences.Last().Sequence
                : (int?)null;
        }
        private IEnumerable<(string FileName, int Sequence)> GetFileNamesAndSequences() =>
            Directory.GetFiles(_directory, $"{_fileNamePrefix}*.log").
                Select(
                    _ =>
                    {
                        var fileNameParts = _.Split('.');
                        return (_, Sequence: int.Parse(fileNameParts[fileNameParts.Length - 2]));
                    }).
                OrderBy(_ => _.Sequence);
    }
