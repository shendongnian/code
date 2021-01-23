        NameValueCollection POST = Request.Form;
        int STATUS;
        int responcode;
        try
        {
            A = int.Parse(POST["status"]);
        }
        catch (Exception)
        {
            status = 0;
        }
        if (A == 1)
        {
            responcode = 200;   
           
            //when A = 1, i want to store A value to (buffer on something <-- this what i want to ask)).
            Session["Avalie"] = A;
            so i can call the value anytime in page2.
        }
        else
        {
            responcode = 400;              
        }
        Response.StatusCode = responcode;
    }
