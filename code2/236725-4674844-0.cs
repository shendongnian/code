	public partial class ItemMap : ClassMap< Item >
	{
		Table( "NamedItem" ) ;
		Id(x => x.Id, "Id" )
			.Not.Nullable()
			.GeneratedBy.Guid();
		Map( x => x.Country )
			.Column( "Country" )
			.Not.Nullable( )
			.Length( 255 ) ;
	
		Map( x => x.Category )
			.Column( "Category" )
			.Not.Nullable( )
			.Length( 255 ) ;
		...
		HasMany< ItemName >( x => x.ItemNames )
			.KeyColumns.Add( "NamedItemId" )
			.Table( "AlternateNames" )
			.LazyLoad( )
			.Cascade.None( )
			.AsSet() ;
		...
	}
