	public class TestViewModel<TEntity> : ViewModelBase
	{
		private readonly ODADomainContext _context = new ODADomainContext();
		private readonly DomainCollectionView<TEntity> _view;
		private readonly DomainCollectionViewLoader<TEntity> _loader;
		private readonly EntityList<TEntity> _source;
		private bool _isGridEnabled;
		/// <summary>
		/// Initializes a new instance of the TestViewModel class.
		/// </summary>
		public TestViewModel()
		{
			this._source = new EntityList<TEntity>(this._context.GetEntitySet<TEntity>);
			this._loader = new DomainCollectionViewLoader<TEntity>(
				 this.LoadSampleEntities,
				 this.OnLoadSampleEntitiesCompleted);
			this._view = new DomainCollectionView<TEntity>(this._loader, this._source);
			INotifyCollectionChanged notifyingSortDescriptions =
		(INotifyCollectionChanged)this.CollectionView.SortDescriptions;
			notifyingSortDescriptions.CollectionChanged +=
			  (sender, e) => this._view.MoveToFirstPage();
			using (this.CollectionView.DeferRefresh())
			{
				this._view.PageSize = 10;
				this._view.MoveToFirstPage();
			}
		}
		#region View Properties
		public bool IsGridEnabled
		{
			get
			{
				return this._isGridEnabled;
			}
			private set
			{
				if (this._isGridEnabled != value)
				{
					this._isGridEnabled = value;
					this.RaisePropertyChanged("IsGridEnabled");
				}
			}
		}
		public ICollectionView CollectionView
		{
			get { return this._view; }
		}
		#endregion
		private LoadOperation<TEntity> LoadSampleEntities()
		{
			this.IsGridEnabled = false;
			return this._context.Load(
				 this._context.GetBudgetsQuery());
		}
		private void OnLoadSampleEntitiesCompleted(LoadOperation<TEntity> op)
		{
			this.IsGridEnabled = true;
			if (op.HasError)
			{
				// TODO: handle errors
				_view.PageSize = 0;
				op.MarkErrorAsHandled();
			}
			else if (!op.IsCanceled)
			{
				this._source.Source = op.Entities;
				_view.PageSize = 10;
				this._view.MoveToFirstPage();
				if (op.TotalEntityCount != -1)
				{
					this._view.SetTotalItemCount(op.TotalEntityCount);
				}
			}
		}
		////public override void Cleanup()
		////{
		////    // Clean own resources if needed
		////    base.Cleanup();
		////}
	}
	// http://blog.zoolutions.se/post/2010/04/05/Generic-Repository-for-Entity-Framework-for-Pluralized-Entity-Set.aspx
	public static class ObjectContextExtensions
	{
		internal static EntitySetBase GetEntitySet<TEntity>(this ObjectContext context)
		{
			EntityContainer container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
			Type baseType = GetBaseType(typeof(TEntity));
			EntitySetBase entitySet = container.BaseEntitySets
				.Where(item => item.ElementType.Name.Equals(baseType.Name))
				.FirstOrDefault();
			return entitySet;
		}
		private static Type GetBaseType(Type type)
		{
			var baseType = type.BaseType;
			if (baseType != null && baseType != typeof(EntityObject))
			{
				return GetBaseType(type.BaseType);
			}
			return type;
		}
	}
