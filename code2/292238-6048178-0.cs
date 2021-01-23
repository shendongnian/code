    class MyOrbInitializer : omg.org.PortableInterceptor.ORBInitializer
    {
        public void post_init(omg.org.PortableInterceptor.ORBInitInfo info)
        {
            // Nothing to do
        }
        public void pre_init(omg.org.PortableInterceptor.ORBInitInfo info)
        {
            omg.org.IOP.Codec codec = info.codec_factory.create_codec(
                new omg.org.IOP.Encoding(omg.org.IOP.ENCODING_CDR_ENCAPS.ConstVal, 1, 2));
            Program.m_codec = codec;
        }
    }
    class Program
    {
        public static omg.org.IOP.Codec m_codec;
        static void Main(string[] args)
        {
            IOrbServices orb = OrbServices.GetSingleton();
            orb.OverrideDefaultCharSets(CharSet.UTF8, WCharSet.UTF16);
            orb.RegisterPortableInterceptorInitalizer(new MyOrbInitializer());
            orb.CompleteInterceptorRegistration();
    ...
            MarshalByRefObject objRef = context.resolve(names);
            string origObjData = orb.object_to_string(objRef);
            Ch.Elca.Iiop.CorbaObjRef.Ior iorObj = new Ch.Elca.Iiop.CorbaObjRef.Ior(origObjData);
            CodeSetComponentData cscd = new CodeSetComponentData(
                (int)Ch.Elca.Iiop.Services.CharSet.UTF8,
                new int[] { (int)Ch.Elca.Iiop.Services.CharSet.UTF8 },
                (int)Ch.Elca.Iiop.Services.WCharSet.UTF16,
                new int[] { (int)Ch.Elca.Iiop.Services.WCharSet.UTF16 });
            omg.org.IOP.TaggedComponent codesetcomp = new omg.org.IOP.TaggedComponent(
                omg.org.IOP.TAG_CODE_SETS.ConstVal, m_codec.encode_value(cscd));
            iorObj.Profiles[0].TaggedComponents.AddComponent(codesetcomp);
            string newObjData = iorObj.ToString();
            MarshalByRefObject newObj = (MarshalByRefObject)orb.string_to_object(newObjData);
            ILicenseInfo li = (ILicenseInfo)newObj;
    ...
        }
