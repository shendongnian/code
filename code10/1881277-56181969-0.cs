     private void ReadyToProcessNextGood(object sender, ReadyToStartNewGoodItemEventArgs e)
        {
                //maybe some checks here to make sure you have the right data
                BusinessMethodHere(e.processId, e.SectNo);
        }
    
    public void BusinessMethodHere( string processId, string sectNo )
    {
                //Remove reserved good.
                _ItemRepository.Delete(sectNo);
                var items = _ItemRepository.GetGoodsByProcessId(processId);
    
                //Going to reserve remaining items
                ReserveGoods(items);
    }
