    public class MainActivity : Activity, Response.IListener, Response.IErrorListener
    {
        public void OnErrorResponse(VolleyError p0)
        {
        }
        public void OnResponse(Object p0)
        {
            if(p0 is JSONObject response)
            {
                // Do your logic here with response
            }
        }
       /......
    }
