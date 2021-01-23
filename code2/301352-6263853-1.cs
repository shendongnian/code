    foreach (var courierTypeRegion in courierOrderByDesc)
                {
    var courierRegionCopy = courierTypeRegion;    
                    if (remaining >= courierTypeRegion.CourierType.PalletsPerTrailer && !processed)
                    {
                        courierRegionCopy.CurrentAllocation = courierTypeRegion.CourierType.PalletsPerTrailer;
                        courierTypeRegionOutput.Add(courierRegionCopy);
                        processed = true;
                    }
    
                    if (!processed)
                    {
                        if (courierOrderByDesc[courierCurrent + 1] != null)
                        {
                            if (remaining > courierOrderByDesc[courierCurrent + 1].CourierType.PalletsPerTrailer)
                            {
                                courierRegionCopy.CurrentAllocation = remaining;
                                courierTypeRegionOutput.Add(courierRegionCopy);
                                processed = true;
                            }
                        }
                    }
                    courierCurrent++;
                }
