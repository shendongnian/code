    public class ResponseResult{
      public bool IsOkay;
      public string ErrCode;
    }
    public static class ResponseExtracter
    {
      //STARTING OFF HERE WITH THE NEW VERSION OF YOUR METHOD
      public static bool ProcessErrorCode(object response)
      {
        Func<object, ResponseResult> processor = null;
        ResponseResult result = new ResponseResult() 
        { 
          IsOkay = false, ErrCode = "UNKNOWN"
        };
        //try to get processor based on object's type
        //then invoke it if we find one.
        if (_processors.TryGetValue(response.GetType(), out processor))
          result = processor(response);
        if (result.IsOkay)
          return true;
        string msg = "Operation resulted in error code:" + result.ErrCode;
        LogErrorCode(msg);
        return false;
      }
      //A lot better no?
      //NOW FOR THE INFRASTRUCTURE
      static Dictionary<Type, Func<object, ResponseResult>> _processors 
        = new Dictionary<Type, Func<object, ResponseResult>>();
      static ResponseExtracter()
      {
        //this can be replaced with self-reflection over methods
        //with attributes that reference the supported type for
        //each method.
        _processors.Add(typeof(Response<AResponseCode>), (o) =>
        {
          AResponseCode code = ((Response<AResponseCode>)o).Code;
          return new ResponseResult
          {
            IsOkay = code == AResponseCode.Ok,
            ErrCode = code.ToString()
          };
        });
        _processors.Add(typeof(Response<BResponseCode>), (o) =>
        {
          BResponseCode code = ((Response<BResponseCode>)o).Code;
          return new ResponseResult
          {
            IsOkay = code == BResponseCode.Ok,
            ErrCode = code.ToString()
          };
        });
        _processors.Add(typeof(DataResponse<CResponseCode, string>),
          (o) =>
          {
            CResponseCode code = ((DataResponse<CResponseCode, string>)o).Code;
            return new ResponseResult
            {
              IsOkay = code == CResponseCode.Ok,
              ErrCode = code.ToString()
            };
          });
      }
    }
