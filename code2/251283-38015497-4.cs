    [DataContract]
    class ConstructedDataContract
    {
        [OnDeserializing]
        void OnDeserializing(StreamingContext context)
        {
            ConstructorInfo ci = this.GetType().GetConstructor(new Type[] { });
            if (ci != null)
            {
                ci.Invoke(this, new object[] { });
            }
        }
    }
