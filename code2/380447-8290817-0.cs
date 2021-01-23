    namespace UserSite //Classes For my site
    {
        namespace General
        {
            public class CodeWithMessage
            {         
                public int Code { get; set; }
                public string Message { get; set; }
            }
         }
    }
    //usage
    CodeWithMessage CWM = new CodeWithMessage();
    CWM.Message = "That url Is In Use";
    CWM.Code = 0;
