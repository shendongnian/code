	public interface IContextMigrator : IDisposable
	{
		void Migrate();
	}
	/// <summary>
	/// Class responsible for migration of a DbContext.
	/// Used by ApplicationBuilderExtensions to perform migrations.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal sealed class ContextMigrator<T> : IContextMigrator
		where T : DbContext
	{
		private readonly T context;
		public ContextMigrator(T context)
		{
			this.context = context;
		}
		public void Migrate()
		{
			try
			{
				this.context.Database.Migrate();
			}
			catch (Exception e)
			{
				throw new MigrationException(context.GetType().Name, e);
			}
		}
		public void Dispose()
		{
		}
	}
