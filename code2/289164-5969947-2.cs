    public abstract class PropertySpy<T> where T : PropertySpy, new()
    {
        public static T Create()
        {
            T result = new T();
            // … whatever initialization needs to be done goes here …
            result.RegisterForEvents();
            return result;
        }
        …
    }
    public class ScenarioOnePropertySpy : PropertySpy<ScenarioOnePropertySpy>
    {
        …
    }
    ScenarioOnePropertySpy spy = ScenarioOnePropertySpy.Create();
