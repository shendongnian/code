    public void MainLoop()
    {
        while (true)
        {
            string item;
            lock( ListOfStrings )
            {
                if( ListOfStrings.Count == 0 )
                    continue;
                item = ListOfStrings[0];
                ListOfStrings.RemoveAt( 0 );
            }
            //do something with item
        }
    }
