    [Serializable]
    public class Ref<T>
    {
        public readonly T Value;
        public readonly int Id;
        public Ref(T value) { Value = value; Id = value.GetHashCode(); }
        protected class RefSurrogate : ISerializationSurrogate
        {
            Dictionary<int, Ref<T>> Instances = new Dictionary<int, Ref<T>>();
            public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
            {
                var refs = (Ref<T>)obj;
                info.AddValue(nameof(Id), refs.Id);
                if (!Instances.ContainsKey(refs.Id))
                {
                    Instances.Add(refs.Id, refs);
                    info.AddValue(nameof(Value), refs.Value);
                }
            }
            public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
            {
                var id = (int)info.GetInt32(nameof(Id));
                if (Instances.TryGetValue(id, out var refs))
                    return refs;
                else
                    return Instances[id] = new Ref<T>((T)info.GetValue(nameof(Value), typeof(T)));
            }
        }
        public static SurrogateSelector AddTo(SurrogateSelector ss)
        {
            ss.AddSurrogate(typeof(Ref<T>), new StreamingContext(StreamingContextStates.All), new RefSurrogate());
            return ss;
        }
    }
