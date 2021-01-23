    BlockingCollection<MyClass> bc = BlockingCollection<MyClass>(new ConcurrentQueue<MyClass>());
    void GetStuff()
    {
        if(!bc.IsCompleated) //check to see if CompleatedAdding() was called and the list is empty.
        {
            try
            {
                MyClass item = bc.Take();
                //Work with item
            }
            catch (InvalidOpperationExecption)
            {
                //Take is marked as completed and is empty so there will be nothing to take
            }
        }
    }
