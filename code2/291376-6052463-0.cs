    public ActionResult Validatecall()
    {
        ActionResult result;
        try
        {
    
        }
        catch (Exception)
        {
           result = JavaScript("$('#dvErrorMsg').show()");
        }
        return result;
    }
