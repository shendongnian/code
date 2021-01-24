    public class SomeController: ControllerBase {  
        private IConfiguration _iconfiguration;  
        public SomeController(IConfiguration iconfiguration) {  
            _iconfiguration = iconfiguration;  
        }
    void SomeMethod(){
    string appUrl = _iConfiguration.GetValue<string>("applicationUrl","someDefaultValue")
