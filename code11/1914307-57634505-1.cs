    public class TestConfigProvider : ConfigurationProvider {
        public override void Load() {
            var initialData = new Dictionary<string, string>
            {
                {"array:entries:0", "value0"},
                {"array:entries:1", "value1"}
            };
            foreach (var pair in initialData) {
                Data.Add(pair.Key, pair.Value);
            }
        }
    }
