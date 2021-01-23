     [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Automapper_Contact_Details_Json_Can_Be_Mapped()
        {
            // Setup 
           
            DateTime testDate = DateTime.Now;
            var json = new ContactDetailsJson
            {
                CompanyName = "company",
                ContactId = "12345",
                FirstName = "first",
                LastName = "last",
                Owned = true,
                Title = "title",
                UpdatedDate = testDate
            };
            Mapper.CreateMap<ContactDetailsJson, ExternalContactSearchResultsViewModel.ContactResultViewModel>()
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyName))
            .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.ContactId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.HasAccess, opt => opt.MapFrom(src => src.Owned))
            .ForMember(dest => dest.Headline, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.LastUpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
            .ForMember(dest => dest.PublicUrl, opt => opt.Ignore()); 
            // Act 
            var result = Mapper.Map<ContactDetailsJson, ExternalContactSearchResultsViewModel.ContactResultViewModel>(json);
            // Verify 
            Assert.IsNotNull(result, "result was null");
            Assert.AreEqual("company", result.Company);
            Assert.AreEqual("12345", result.ContactId);
            Assert.AreEqual("first", result.FirstName);
            Assert.AreEqual("last", result.LastName);
            Assert.AreEqual(true, result.HasAccess);
            Assert.AreEqual("title", result.Headline);
            Assert.AreEqual(testDate, result.LastUpdatedDate);
        }
    }
