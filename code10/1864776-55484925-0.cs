    if ( _repository.HAWBAssets.FirstOrDefault(i => i.HAWB == hawb)== null)
        {
         _repository.Insert(entity);
            uniqueHawb = true;
        }
