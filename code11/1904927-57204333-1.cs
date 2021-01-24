	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<Post, PostViewModel>(MemberList.None).ReverseMap();
		}
	}
