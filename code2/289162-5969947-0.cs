    public class PropertySpyFactory<T> where T : PropertySpy, new()
    {
        public static T Create()
        {
            T result = new T();
            // … whatever initialization needs to be done goes here …
            result.RegisterForEvents();
            return result;
        }
    }
    ScenarioOnePropertySpy spy = PropertySpyFactory<ScenarioOnePropertySpy>.Create();
