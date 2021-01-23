                var fb = new FacebookClient("my token"); 
                dynamic parameters = new ExpandoObject();
                parameters.message = "the publish msg"; 
                dynamic result = fb.Post("/me/feed", parameters); 
                var id = result.id; 
                var res = fb.Post("/" + id + "/likes"); 
