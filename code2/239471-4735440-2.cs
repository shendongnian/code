            if (HttpContext.Current != null) {
					NameValueCollection tmp = new NameValueCollection(HttpContext.Current.Request.ServerVariables);
					foreach (string i in tmp.Keys) {
						
					}
                if (HttpContext.Current.Server != null) {
                    if (HttpContext.Current.Server.GetLastError() != null) {
                    }
                }
                if (HttpContext.Current.Session != null) {
                    foreach (string i in HttpContext.Current.Session.Keys) {
                    }
                }
                if (HttpContext.Current.Request.Cookies != null) {
                    foreach (string i in HttpContext.Current.Request.Cookies.Keys) {
                    }
                }
                if (HttpContext.Current.Response.Cookies != null) {
                    foreach (string i in HttpContext.Current.Response.Cookies.Keys) {
                    }
                }
                if (HttpContext.Current.Items != null) {
                    foreach (string i in HttpContext.Current.Items.Keys) {
                    }
                }
                if (HttpContext.Current.Request.Form != null) {
                    foreach (string i in HttpContext.Current.Request.Form.Keys) {
                    }
                }
            }
