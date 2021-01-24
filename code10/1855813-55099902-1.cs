    [HttpPost]
    public HttpResponseMessage deletevacs([FromUri]int staffid, [FromUri] int[] vacs)
    {
        try
        {
    	obj.ExecNonQuery(string.Format("delete from HR_AssRole_Dep where staff_key={0} and Role=7 and Current_Flag=1 and VacMKey ={1}"
    		       , staffid
    		       , vacs));
        }
        catch (Exception ex)
        {
        }
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
