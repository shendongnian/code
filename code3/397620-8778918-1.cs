    dgPrimary.ItemsSource = Directory.GetFiles( @"C:\" )
                                        .Select( ( nm, index ) => new
                                        {
                                            Original = System.IO.Path.GetFileName( nm ),
                                            New = string.Format( "{0}_{1}{2}", System.IO.Path.GetFileNameWithoutExtension( nm ), index, System.IO.Path.GetExtension( nm ) )
                                        } );
