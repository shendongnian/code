var res = _pplEntities.ApiConsumers
            .Where(ac => ac.ConsumerId  == request.ConsumerId 
					  && ac.ConsumerSecret == request.ConsumerSecret)
          .ToListAsync()
												
if(res.Any())
{
     //to stuff and things
}
