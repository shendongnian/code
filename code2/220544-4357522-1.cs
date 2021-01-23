    public class AutomapBootstrap
    {
        public static void InitializeMap()
        {
            Mapper.CreateMap<CreateBookmarkRequest, TagsToSaveRequest>()
                .ForMember(dest => dest.TagsToSave, opt => opt.MapFrom(src => src.BookmarkTags))
                .ForMember(dest => dest.SystemObjectId, opt => opt.UseValue((int)SystemObjectType.Bookmark))
                .ForMember(dest => dest.SystemObjectRecordId, opt => opt.Ignore());
            
        }
    }
