    foreach (var courierTypeRegion in courierOrderByDesc)
                {
    var courierRegionCopy = courierTypeRegion;    
                    if (remaining >= courierTypeRegion.CourierType.PalletsPerTrailer && !processed)
                    {
                        courierTypeRegion.CurrentAllocation = courierTypeRegion.CourierType.PalletsPerTrailer;
                        courierTypeRegionOutput.Add(courierRegionCopy);
                        processed = true;
                    }
    
                    if (!processed)
                    {
                        if (courierOrderByDesc[courierCurrent + 1] != null)
                        {
                            if (remaining > courierOrderByDesc[courierCurrent + 1].CourierType.PalletsPerTrailer)
                            {
                                courierTypeRegion.CurrentAllocation = remaining;
                                courierTypeRegionOutput.Add(courierRegionCopy);
                                processed = true;
                            }
                        }
                    }
                    courierCurrent++;
                }
