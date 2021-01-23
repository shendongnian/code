	public abstract class SitePageBase<T> : SitePageBase where T : SitePageBase<T>
	{
		protected override void OnInit( EventArgs e )
		{
			BuildUpDerived();
			base.OnInit( e );
		}
		protected void BuildUpDerived()
		{
			ContainerProvider.Container.BuildUp( this as T );
		}
	}
