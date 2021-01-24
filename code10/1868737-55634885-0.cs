C#
public bool Delete(int id)
        {
            try
            {
                var redisManager = new RedisManagerPool(Global.RedisConnector);
                using (var redis = redisManager.GetClient())
                {                                   
                    var items = redis.GetAllItemsFromSortedSet("BookingRequests");
                    foreach (var item in items)
                    {
                        var dto = item.FromJson<BookingRequestModel>();
                        if (dto.Id == id)
                        {
                            redis.RemoveItemFromSortedSet("BookingRequests", item);
                            break;
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
