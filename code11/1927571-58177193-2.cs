     class FriendlyMessage : Java.Lang.Object, IParcelable
    {
        public String text;
        public String name;
        public String photoUrl;
        public String UId;
        public void setUid(String Id) {
            this.UId = Id;
        }
        public String getUId() {
            return UId;
        }
        private static readonly MyParcelableCreator<FriendlyMessage> _create = new MyParcelableCreator<FriendlyMessage>(GetMessage);
        //[ExportField("CREATOR")]
        [ExportField("CREATOR")]
        public static MyParcelableCreator<FriendlyMessage> Create()
        {
            return _create;
        }
        private static FriendlyMessage GetMessage(Parcel parcel)
        {
            FriendlyMessage msg = new FriendlyMessage();
            msg.text = parcel.ReadString();
            msg.name = parcel.ReadString();
            msg.photoUrl = parcel.ReadString();
            msg.UId = parcel.ReadString();
            return msg;
        }
        public FriendlyMessage()
        {
        }
        public FriendlyMessage(String text, String name, String photoUrl)
        {
            this.text = text;
            this.name = name;
            this.photoUrl = photoUrl;
            this.UId = Guid.NewGuid().ToString();
        }
        public String getText()
        {
            return text;
        }
        public void setText(String text)
        {
            this.text = text;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getPhotoUrl()
        {
            return photoUrl;
        }
        public void setPhotoUrl(String photoUrl)
        {
            this.photoUrl = photoUrl;
        }
        public int DescribeContents()
        {
            throw new NotImplementedException();
        }
        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(text);
            dest.WriteString(name);
            dest.WriteString(photoUrl);
            dest.WriteString(UId);
        }
        public static HashMap MsgModelToMap(FriendlyMessage msg)
        {
            HashMap map = new HashMap();
            map.Put("text", msg.text);
            map.Put("name", msg.name);
            map.Put("photoUrl", msg.photoUrl);
            map.Put("UId", msg.UId);
            return map;
        }
        public override string ToString()
        {
            return "name = " + name +" text = " + text + " photoUrl= " + photoUrl+ " UId = " + UId;
        }
        public static FriendlyMessage MapToMsgModel(DataSnapshot snapShot)
        {
            FriendlyMessage msg = new FriendlyMessage();
            if (snapShot.GetValue(true) == null)
            {
                return null;
            }
            msg.UId = snapShot.Key;
            msg.text = snapShot.Child("text")?.GetValue(true)?.ToString();
            msg.name = snapShot.Child("name")?.GetValue(true)?.ToString();
            msg.photoUrl = snapShot.Child("photoUrl")?.GetValue(true)?.ToString();
            return msg;
        }
        public  bool Equal_obj(object obj)
        {
            var message = obj as FriendlyMessage;
            return message != null &&
                   text == message.text &&
                   name == message.name &&
                   photoUrl == message.photoUrl &&
                   UId == message.UId;
        }
    }
  
