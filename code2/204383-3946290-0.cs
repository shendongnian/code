    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using NLog;
    [DataContract]
    public class UserSettings : IExtensibleDataObject
    {
        ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }
        [DataMember]
        public int TestIntProp { get; set; }
        private string _testStringField;
    }
    public static class SettingsManager
    {
        private static Logger _logger = LogManager.GetLogger("SettingsManager");
        private static UserSettings _settings;
        private static readonly string _path =
            Path.Combine(
                Path.GetDirectoryName(
                    System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName),
                "settings.json");
        public static UserSettings Settings
        {
            get
            {
                return _settings;
            }
        }
        public static void Load()
        {
            if (string.IsNullOrEmpty(_path))
            {
                _logger.Trace("empty or null path");
                _settings = new UserSettings();
            }
            else
            {
                try
                {
                    using (var stream = File.OpenRead(_path))
                    {
                        _logger.Trace("opened file");
                        _settings = SerializationExtensions.LoadJson<UserSettings>(stream);
                        _logger.Trace("deserialized file ok");
                    }
                }
                catch (Exception e)
                {
                    _logger.TraceException("exception", e);
                    if (e is InvalidCastException
                        || e is FileNotFoundException
                        || e is SerializationException
                        )
                    {
                        _settings = new UserSettings();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
        public static void Save()
        {
            if (File.Exists(_path))
            {
                string destFileName = _path + ".bak";
                if (File.Exists(destFileName))
                {
                    File.Delete(destFileName);
                }
                File.Move(_path, destFileName);
            }
            using (var stream = File.Open(_path, FileMode.Create))
            {
                Settings.WriteJson(stream);
            }
        }
    }
    public static class SerializationExtensions
    {
        public static T LoadJson<T>(Stream stream) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            object readObject = serializer.ReadObject(stream);
            return (T)readObject;
        }
        public static void WriteJson<T>(this T value, Stream stream) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, value);
        }
    }
