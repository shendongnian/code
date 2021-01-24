    public class BaseController
    {
         protected bool ValidateApiResult(ApiResult api,out IHttpActionResult result)
         {
             if(api == null)
             {
                  result  = Ok(GenerateErrorsModel(404, TokenNotFoundMessage));
                  return false;
             }
             
             if (api.IsExpired)
             {
                  result  = Ok(GenerateErrorsModel(400, TokenExpiredMessage));
                  return false;
             }
             result = default;
             return true;
         } 
    }
