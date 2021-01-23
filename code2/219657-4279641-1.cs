    public class ErrorList:List<string>
    {
        public bool HasErrors{get{return Count>0;}}
    }
    public void ValidateEntries(ErrorList errors)
    {
        if (this.CompanyName.Length < 6)
            errors.Add("Company name must be of at least six characters.");
        if (DateTime.Parse(this.FYStarting) > DateTime.Parse(this.FYEnding))
           Errors.Add("Invalid financial year period."
    }
    public void CallingFunction()
    {
        var errors=new ErrorList();
        ValidateEntries();
        if(erros.HasErrors)
        {
            ShowMessage(string.Join("\r\n",errors));
            return;
        }
        DoStuff();
    }
