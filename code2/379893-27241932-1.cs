		public class Child{	public string Name  {get; set; }}
		public class ChildDto{	public string NickName {get; set; }}
		public class Parent{	public virtual IEnumerable<Child> Children  {get; set; }}
		public class ParentDto{	public IEnumerable<ChildDto> Kids  {get; set; }}
		private static void Main()
		{
			AutoMapper.Mapper.CreateMap<Parent, ParentDto>().ForMember(d=>d.Kids, opt=>opt.MapFrom(src=>src.Children));
			AutoMapper.Mapper.CreateMap<Child, ChildDto>().ForMember(d=>d.NickName, opt=>opt.MapFrom(src=>src.Name));
			
			var pList = new HashSet<Parent>{
				new Parent{ Children = new HashSet<Child>{new Child{Name="1"}, new Child{Name="2"}}},
				new Parent{ Children = new HashSet<Child>{new Child{Name="3"}, new Child{Name="4"}}},
			};
			
			var parentVm = AutoMapper.Mapper.Map<IEnumerable<Parent>, IEnumerable<ParentDto>>(pList);
			parentVm.Dump();	
		}
