    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.FullNameRecording).CustomType<PcmAudioStreamAsByteArray>()
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
