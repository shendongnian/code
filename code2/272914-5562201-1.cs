    // create and save a child with a known parent
    var c = new TableChild {
        Parent = session.Load<TableParent>( parent_id );
    };
    session.Save( c );
