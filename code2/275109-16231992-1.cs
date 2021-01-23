    [TestFixture]
    public class AutomapperChainingMappingTest
    {
        [Test]
        public void ChainMapping_NullProperty_DefaultValueSet()
        {
            AutoMapper.Mapper.CreateMap<User, UserViewModel>()
                      .ForMember(x => x.FacebookUniqueId, o => o.MapFrom(x => x.FacebookUser.FacebookUniqueId));
            var source = new User();
            var model = AutoMapper.Mapper.Map<UserViewModel>(source);
            Assert.AreEqual(model.FacebookUniqueId, default(long));
        }
    }
    public class User
    {
        public FacebookUser FacebookUser { get; set; }
    }
    public class UserViewModel
    {
        public long FacebookUniqueId { get; set; } 
    }
    public class FacebookUser
    {
        public long? FacebookUniqueId { get; set; }
    }
