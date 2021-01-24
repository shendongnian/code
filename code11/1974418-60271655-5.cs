`
public class TaskStatusDtoResolver : IValueResolver<Task, TaskDto, TaskStatusDto?>
{
    public TaskStatusDto? Resolve(Task source, TaskDto destination, TaskStatusDto? member, ResolutionContext context)
    {
        if (source.Status == null)
        {
            return null;
        }
        return new TaskStatusDto
        {
            Status = context.Mapper.Map<StatusDto>(source.Status),
            Timestamp = source.StatusLastModified == null ? DateTime.Now : source.StatusLastModified.Value
            // I am using DateTime.Now as the default value for null
         };
    }
}
`
And you can use the following configuration:
`
.configuration
    CreateMap<Status, StatusDto>();
.configuration
    CreateMap<Task, TaskDto>()
        .ForMember(dest => dest.Status, opt => opt.MapFrom<TaskStatusDtoResolver>());
`
[See the working example here][2]
----------------------------
Alternatively you can define all the mappings in the configuration:
`
var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Status, StatusDto>();
    cfg.CreateMap<Task, TaskDto>()
        .ForMember(
         dest => dest.Status,
         src => src.MapFrom((task, taskDto, member, context) =>
         {
             return task.Status == null ? null as TaskStatusDto? : new TaskStatusDto()
             {
                 Timestamp = task.StatusLastModified.Value,
                 Status = context.Mapper.Map<StatusDto>(task.Status)
             };
         }
     ));
});
`
  [1]: http://docs.automapper.org/en/stable/Custom-value-resolvers.html
  [2]: https://dotnetfiddle.net/3qgUYG
