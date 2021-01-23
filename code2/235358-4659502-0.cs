        internal class ApplicationCode
        {
            private CodeService _codeService = new CodeService();
    
            public int Code { get; set; }
            public bool IsValidCode
            {
                get
                {
                    return _codeService.DoesIntrumentCodeExist(Code.ToString());
                }
            }
        }
    
        internal class CodeService
        {
            private IEnumerable<string> _instrumentCodes;
    
            public CodeService()
            {
                //instantiate this in another way perhaps via DI....
                _instrumentCodes = new List<string>();
            }
    
            public bool DoesIntrumentCodeExist(String instrumentCode)
            {
                foreach (String code in _instrumentCodes)
                {
                    if (code == instrumentCode)
                        return true;
                }
    
                return false;
            }
        }
