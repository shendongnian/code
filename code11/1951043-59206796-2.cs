    catch (Exception e)
    {
        _r.ResponseCode = "002";
        if (UserSession.GetEnableDebugMode())
        {
            _r.ResponseBody = e.InnerException == null ? e.Message : e.Message + "  " + e.InnerException.Message;
        }
        else
        {
            _r.ResponseBody = e.Message;
        }
        return Content(HttpStatusCode.InternalServerError, _r);
    }
