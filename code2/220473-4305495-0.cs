    internal class HorizontalPictureScrollerSerializer : CodeDomSerializer
        {
            public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
            {
                var baseClassSerializer = (CodeDomSerializer) manager.
                                                                  GetSerializer(
                                                                      typeof (HorizontalPictureScroller).BaseType,
                                                                      typeof (CodeDomSerializer));
    
                return baseClassSerializer.Deserialize(manager, codeObject);
            }
    
            public override object Serialize(IDesignerSerializationManager manager, object value)
            {
            
                var baseClassSerializer = (CodeDomSerializer) manager.GetSerializer(
                                                                      typeof (HorizontalPictureScroller).BaseType,
                                                                      typeof (CodeDomSerializer));
    
                object codeObject = baseClassSerializer.Serialize(manager, value);
    
            
                return codeObject;
            }
        }
    
        [DesignerSerializerAttribute(typeof (HorizontalPictureScrollerSerializer), typeof (CodeDomSerializer))]
        //THE QUESTION IS HERE!
        public partial class HorizontalPictureScroller : UserControl
        {
                             .......
        }
