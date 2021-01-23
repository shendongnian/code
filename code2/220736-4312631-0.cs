	string userName = ""; // Substitute with logic for obtaining username
	string folder = ResolveUrl( "~/Uploads" );
	folder = System.IO.Path.Combine( folder, userName );
	if ( !System.IO.Directory.Exists( folder ) )
		System.IO.Directory.CreateDirectory( folder );
