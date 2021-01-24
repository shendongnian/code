`C#
_container.Register<Ixxx, Data>();
_container.Register<IData<Ixxx>, XxxData>();
_container.RegisterDecorator<IData<Ixxx>, Data1Decorator<Ixxx>>();
_container.RegisterDecorator<IData<Ixxx>, Data2Decorator<Ixxx>>():
`
`C#
	public interface IData<out TData>
    {
		TData Data { get; }
		Task Load();
    }
	
	public abstract class DataDecorator<TData> : IData<TData>
    {
		public readonly IData<TData> _data;
		
		public TData Data => _data.Data;
		
		protected DataDecorator(IData<TData> data) => _data = data;
		
		public virtual Task Load() => _data.Load();
    }
`
`C#
	public interface Ixxx :
		Ixxx1,
        Ixxx2
    {
    }
	
	public class XxxData : IData<Ixxx>
	{
		public Ixxx Data { get; }
		
		public XxxData(Ixxx data) => Data = data;
		
		public Task Load() => Task.Run(() => { });
	}
`
`C#
	public interface Ixxx1
    {
        public IEnumerable<...> x1 { get; set; }
    }
	
    public class Data1Decorator<TData> : DataDecorator<TData>
		where TData : Ixxx1
    {
        public Data1Decorator(IData data) : base(data)
        {
        }
        public override Task Load()
        {
            return Task.WhenAll(new List<Task>() { ..., base.Load() })
            .ContinueWith((b) =>
            { 
                   Data.x1 = ...
            });
        }
    }
`
