    ArrayList list = new ArrayList();
    list.AddRange( mApples );
    list.AddRange( mBananas );
    list.AddRange( mOranges );
    
    foreach( Fruit item in list )
    {
    	item.Slice();
    }
