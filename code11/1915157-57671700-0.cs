if (!string.Equals(Request.HttpMethod, "POST"))
{
   Response.StatusCode = 405;
   Response.End();
}
