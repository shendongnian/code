     public HttpResponseMessage PostTest([FromBody] MyPostObject obj)
    {
        try
        {
 	    ResponseModel _objResponseModel = new ResponseModel();
            MyRespObject response = SomeMethod(obj);
            return this.ToActionResult(response);
  		_objResponseModel.Data = response;
                _objResponseModel.Status = response.Status;
                _objResponseModel.Message = "success";
        }
        catch (Exception ex) {
            _objResponseModel.Data = null;
                _objResponseModel.Status = false;
                _objResponseModel.Message = "failed";
        }
	 return Request.CreateResponse(HttpStatusCode.OK, _objResponseModel);
    }
    }  
      public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public object Data { set; get; }
      
    }
