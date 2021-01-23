    public class LayoutModel
        {
            public string LayoutFile { get; set; }
            public string IpsTop { get; set; }
            public string IpsBottom { get; set; }
            public string ProfileTop { get; set; }
            public string ProfileBottom { get; set; }
    
            public LayoutModel(string hostname)
            {
                switch (hostname.ToLower())
                {
                    default:
                   
                        LayoutFile = "~/Views/Shared/_BnlLayout.cshtml";
                        IpsBottom = "~/Template/_BnlIpsBottom.cshtml";
                        IpsTop = "~/Template/_BnlTop.cshtml";
                        ProfileTop = "~/Template/_BnlProfileTop.cshtml";
                        break;
                
                    case "something.com":
                        LayoutFile = "~/Views/Shared/_Layout.cshtml";
                        IpsBottom = "~/Template/_somethingBottom.cshtml";
                        IpsTop = "~/Template/_somethingTop.cshtml";
                        ProfileTop = "~/Template/_somethingProfileTop.cshtml";
                        break;
                }
            }
        }
