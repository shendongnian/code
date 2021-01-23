    public class Entity
    {
        public virtual int Id { get; protected set; }
    }
    public class PcmAudioStream
    {}
    public class User : Entity
    {
        private static readonly IDictionary<int, PcmAudioStream> _fullNameRecordingCache;
        private PcmAudioStream _fullNameRecording;
        static User()
        {
            _fullNameRecordingCache = new Dictionary<int, PcmAudioStream>();
        }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual PcmAudioStream FullNameRecording
        {
            get
            {
                if (_fullNameRecordingCache.ContainsKey(Id))
                {
                    return _fullNameRecordingCache[Id];
                }
                // May need to watch for proxies here
                _fullNameRecordingCache.Add(Id, _fullNameRecording);
                return _fullNameRecording;
            }
            set
            {
                if (_fullNameRecordingCache.ContainsKey(Id))
                {
                    _fullNameRecordingCache[Id] = value;
                }
                _fullNameRecording = value;
            }
        }
        // ...
    }
