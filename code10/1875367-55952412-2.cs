    namespace Services.Extension.ProtobufSerializationExtension
    {
        public class ProtobufSerializationServiceElement : BehaviorExtensionElement
        {
            public override Type BehaviorType
            {
                get { return typeof(ProtobufBehavior); }
            }
    
            protected override object CreateBehavior()
            {
                return new ProtobufBehavior();
            }
        }
    }
