    public class MemberContactsDal : DataAccessLayerBase
    {
        public string GetMemberContacts(long memberID, string startsWith, string endsWith, OutputType outputType)
        {
            return GetXml(
                "get_memberContactsXML", 
                outputType, 
                new Tuple("@memberID", DBType.Int64, memberID ), 
                new Tuple("@startsWith1", DBType.String, startsWith), 
                new Tuple("@startsWith2", DBType.String, endsWith)
            );
        }
    }
