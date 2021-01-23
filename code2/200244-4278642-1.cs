    public static void Main()
    {
        WebService service = new WebService();
        try
        {
            service.HelloWorld(new HelloWorldInput());
        }
        catch (SoapException ex)
        {
            if(ex.Actor == "HelloWorld")
                // Do sth with HelloWorldException
        }
        catch (Exception ex)
        {
            // Do sth with Exception
        }
    }
