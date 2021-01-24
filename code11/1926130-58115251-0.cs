public string success() 
{
  string status = RecursiveMethod();
  return status;
}
 public string RecursiveMethod()
 {
   string response = CheckStatus();
   if (response =="fail")
   {
     RecursiveMethod();
   }
   return response;
 }
string CheckStatus()
{
    //Write Logic on which return "success" or "fail"
}
