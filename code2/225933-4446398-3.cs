    public interface IMapper<TModel, TViewModel>
    {
        TViewModel MapModelToView(TModel source);
    }
    
    public class SomeMapper : IMapper<IEnumerable<SomeModel>, IEnumerable<SomeViewModel>>
    {
        public IEnumerable<SomeViewModel> MapModelToView(IEnumerable<SomeModel> source)
        {
            return source.Select(x => new SomeViewModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              Enabled = true //call to your method and resolve
                                          });
        }
    }
