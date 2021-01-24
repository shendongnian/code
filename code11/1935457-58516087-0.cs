public class NodeModel<T>
{
   (...)
   public T Props { get;  set; }
}
you could then help the desrialiser by telling it what type to use.
serialiser.DeserialiseObject<NodeModel<SomeType>>(json);
