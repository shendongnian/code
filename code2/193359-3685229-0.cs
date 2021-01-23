    if (!advertismentsDao.AdvertisementUrlExist(ad.Url))
    {
        if (
            !advertismentsDao.AdvertisementExist(ad.Price, ad.HollidayDuration, ad.Name,
                                                 ad.Description, ad.City, ad.Area, ad.Country,
                                                 ad.Agency))
        {
           advertismentsDao.Save(ad);
           advertismentsDao.CommitChanges();
        }
    }
