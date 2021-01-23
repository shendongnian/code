    public ActionResult Validatecall()
    {
        ActionResult result;
        try
        {
           // do whatever
        }
        catch (Exception)
        {
           result = JavaScript("$('#dvErrorMsg').show();$('#errorMessage').val(/* Put exception message here*/")");
        }
        return result;
    }
