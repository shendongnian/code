    for(int r = 0; r < _Rows; r++) {
        layoutRoot.RowDefinitions.Add( new System.Windows.Controls.RowDefinition( ) { Height = new GridLength( 50, GridUnitType.Pixel ) } );
    }
    for(int c = 0; c < _Columns; c++) {
        layoutRoot.ColumnDefinitions.Add( new System.Windows.Controls.ColumnDefinition( ) { Width = new GridLength( 50, GridUnitType.Pixel ) } );
    }
    for(int r = 0; r < _Rows; r++) {
        for(int c = 0; c < _Columns; c++) {
            var border = new Border( );
            ...
        }
    }
