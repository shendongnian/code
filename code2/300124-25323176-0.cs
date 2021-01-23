                {
                    result = await entities. MyObject1.Include("MyObject2").Where(t => IdList.FirstOrDefault()==t. MyObjectId).ToListAsync();
                }
                else
                {
                    result = await entities. MyObject1.Include("MyObject2").Where(t => IdList.Contains(t. MyObjectId)).ToListAsync();
                }*
