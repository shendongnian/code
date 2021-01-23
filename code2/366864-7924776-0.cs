 	public interface IAccess
	{
    		[OperationContract]
    		[FaultContract(typeof(PermissionDenied_Error))]
    		DtoResponse Access(DtoRequest request);
    }
