            //The solution I found was to ignore Microsoft's 
             // tutorial and publish web service to local IIS
            
                        //change constants.cs
                namespace TodoASMX
                    {
                        public static class Constants
                        {
                            // URL of ASMX service
                            public static string SoapUrl
                            {
                                get
                                {
                                    var defaultUrl = "http://192.168.254.25/TodoService.asmx";
                                    //var defaultUrl = "http://localhost:49178/TodoService.asmx";
                                    if (Device.RuntimePlatform == Device.Android)
                                    {
                                        // defaultUrl = "http://10.0.2.2:49178/TodoService.asmx";
                                        defaultUrl = "http://192.168.254.25/TodoService.asmx";
                                    }
                                    //Also in references.cs
                                    public TodoService()
                                    {
                                        //  this.Url = "http://localhost:49178/TodoService.asmx";
                                        this.Url = "http://192.168.254.25/TodoService.asmx";
                                        // and also in properties window of web reference
                                        //Times like these I really despise Microsoft!!!
