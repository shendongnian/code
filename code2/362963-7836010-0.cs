    public class GetAllRelatedResourcesByParentGuidQuery : IGetAllRelatedResourcesByParentGuidQuery 
    { 
            private readonly IList<Guid> _itemsCheckedForRelations = new List<Guid>(); 
     
            public IEnumerable<IDependency> Invoke(Guid parentCiId,  
                                                      IResoucesByIdQuery getResources) 
            {
    			Reset();
    			return InternalInvoke(parentCiID, getResources);
    		}
    		
            private IEnumerable<IDependency> InternalInvoke(Guid parentCiId,  
                                                      IResoucesByIdQuery getResources) 
            {
                 //actual implementation, when going recursive, call this internal method
            }
    }
    												  
