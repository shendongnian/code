        public class ModelProfile: Profile
        {
            public ModelProfile()
            {
                CreateMap<CreatePostRequestDTO, Post>();
                CreateMap<PostItemDTO, PostItem>();
                CreateMap<PostItemTagDTO, PostItemTag>();
            }
        }
