     protected T GetQueryParam<T>(String name, T defValue = default(T))
            {
                String param = HttpContext.Request.QueryString.Get(name);
                if (String.IsNullOrEmpty(param))
                    param = HttpContext.Request.Params[name];
                if ( String.IsNullOrEmpty(param))
                    param = (String) RouteData.Values[name] ?? String.Empty;
    
                if (String.IsNullOrEmpty(param) )
                    return defValue;
    
                return (T)Convert.ChangeType(param, typeof(T));
            }
