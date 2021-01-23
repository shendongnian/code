	public abstract class RiaQuery : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged values
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		#region Query
		private EntityQuery _Query;
		public EntityQuery Query
		{
			get { return _Query; }
			private set
			{
				if (_Query != value)
				{
					_Query = value;
					RaisePropertyChanged("Query");
				}
			}
		}
		#endregion
		#region Result
		private IEnumerable _Result;
		public IEnumerable Result
		{
			get { return _Result; }
			private set
			{
				if (_Result != value)
				{
					_Result = value;
					RaisePropertyChanged("Result");
				}
			}
		}
		#endregion
		#region ExecuteBusy
		private bool _ExecuteBusy;
		public bool ExecuteBusy
		{
			get { return _ExecuteBusy; }
			private set
			{
				if (_ExecuteBusy != value)
				{
					_ExecuteBusy = value;
					RaisePropertyChanged("ExecuteBusy");
				}
			}
		}
		#endregion
		#region ExecuteCommand
		private DelegateCommand _ExecuteCommand;
		public DelegateCommand ExecuteCommand
		{
			get
			{
				if (_ExecuteCommand == null)
				{
					_ExecuteCommand = new DelegateCommand(o => Execute(o), o => !ExecuteBusy);
				}
				return _ExecuteCommand;
			}
		}
		#endregion
		#region ExecuteException
		private Exception _ExecuteException;
		public Exception ExecuteException
		{
			get { return _ExecuteException; }
			private set
			{
				if (_ExecuteException != value)
				{
					_ExecuteException = value;
					RaisePropertyChanged("ExecuteException");
				}
			}
		}
		#endregion
		public event EventHandler ExecuteBegin;
		public event EventHandler ExecuteComplete;
		public event EventHandler ExecuteSuccess;
		public event EventHandler ExecuteError;
		protected  DomainContext Context;
		public bool CreateQueryEachTime { get; set; }
		public RiaQuery(DomainContext context)
		{
			if (context == null) throw new ArgumentException("context");
			Context = context;
		}
		public void Execute(object param)
		{
			ExecuteBusy = true;
			if (ExecuteBegin != null)
				ExecuteBegin(this, EventArgs.Empty);
			if (CreateQueryEachTime || Query == null)
				CreateQueryInternal();
			Context.Load(Query, LoadBehavior.RefreshCurrent, o =>
			{
				if (o.HasError)
				{
					ExecuteException = o.Error;
					if (ExecuteError != null)
						ExecuteError(this, EventArgs.Empty);
					o.MarkErrorAsHandled();
				}
				else
				{
					Result = o.Entities;
					if (ExecuteSuccess != null)
						ExecuteSuccess(this, EventArgs.Empty);
				}
				if (ExecuteComplete != null)
					ExecuteComplete(this, EventArgs.Empty);
				ExecuteBusy = false;
			}, false);
		}
		private void CreateQueryInternal()
		{
			Query = CreateQuery();
		}
		protected abstract EntityQuery CreateQuery();
	}
	public abstract class RiaQuery<TContext> : RiaQuery
		where TContext : DomainContext
	{
		new protected TContext Context
		{
			get { return base.Context as TContext; }
			set { base.Context = value; }
		}
		public RiaQuery(TContext context) : base(context) { }
	}
	public abstract class RiaQuery<TContext,TEntity> : RiaQuery<TContext>
		where TContext : DomainContext
		where TEntity : Entity 
	{
		new public EntityQuery<TEntity> Query
		{
			get { return base.Query as EntityQuery<TEntity>; }
		}
		new public IEnumerable<TEntity> Result
		{
			get { return base.Result.OfType<TEntity>(); }
		}
		public RiaQuery(TContext context) : base(context) { }
	}
	public class DelegateRiaQuery<TContext> : RiaQuery<TContext>
		where TContext : DomainContext
	{
		protected Func<TContext, EntityQuery> CreateQueryDelegate;
		public DelegateRiaQuery(TContext context, Func<TContext, EntityQuery> createQueryDelegate)
			: base(context)
		{
			if (createQueryDelegate == null) throw new ArgumentException("createQueryDelegate");
			CreateQueryDelegate = createQueryDelegate;
		}
		protected override EntityQuery CreateQuery()
		{
			return CreateQueryDelegate(Context);
		}
	}
	public class DelegateRiaQuery<TContext, TEntity> : RiaQuery<TContext, TEntity> 
		where TContext : DomainContext 
		where TEntity : Entity
	{
		protected Func<TContext, EntityQuery<TEntity>> CreateQueryDelegate;
		public DelegateRiaQuery(TContext context, Func<TContext, EntityQuery<TEntity>> createQueryDelegate) : base(context)
		{
			if (createQueryDelegate == null) throw new ArgumentException("createQueryDelegate");
			CreateQueryDelegate = createQueryDelegate;
		}
		protected override EntityQuery CreateQuery()
		{
			return CreateQueryDelegate(Context);
		}
	}
