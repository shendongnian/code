    public class TypePrimary : ISerializable{
        private Type1 _type1;
        private Type2 _type2;
        private Type3 _type3;
        protected TypePrimary(Type1 type1, Type2, type2, Type3 type3){
            this._type1 = type1;
            this._type2 = type2;
            this._type3 = type3;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("type1", this._type1, typeof (Type1));
            info.AddValue("type2", this._type2, typeof (Type2));
            info.AddValue("type3", this._type3, typeof (Type3));
        }
    
        protected TypePrimary(SerializationInfo info, StreamingContext context)
        {
            this._type1 = (Type1) info.GetValue("type1", typeof (Type1));
            this._type2 = (Type2) info.GetValue("type2", typeof (Type2));
            this._type3 = (Type3) info.GetValue("type3", typeof (Type3));
        }
        // Use public getters to return the types...
    }
