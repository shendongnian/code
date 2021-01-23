    class MyViewModelObject
    {
      void AddItem( MyObject obj )
      {
        App.MyObjectsLibrary.Add( obj );
        MyObjectsByClassification = from myobjects in App.MyObjectsLibrary
                                    group myobjects by myobjects.Classification into c
                                    orderby c.Key
                                    select new PublicGrouping<string, MyObject>(c);
      }
    }
