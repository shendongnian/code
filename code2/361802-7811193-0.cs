    [Serializable]
    public class ColoredFont : ISerializable
    {
        public SerializableFont SerializableFont;
        public Color Color;
    
        private ColoredFont(SerializationInfo info, StreamingContext context)
        {
            Color = (Color)info.GetValue("Color", typeof(Color));
            try
            {
                SerializableFont = (SerializableFont)info.GetValue("SerializableFont", typeof(SerializableFont));
            }
            catch (SerializationException serEx)
            {
                Font f = (Font)info.GetValue("Font", typeof(Font));
                // do something to initialize SerializedFont from 'f'
            }
    
        }
    
        #region ISerializable Members
    
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SerializableFont", SerializableFont);
            info.AddValue("Color", Color);
        }
    
        #endregion
    }
