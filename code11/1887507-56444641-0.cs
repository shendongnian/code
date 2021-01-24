public class LoginViewModel {
   public string ID  { get; set; }
   public string Password  { get; set; }
}
Now, modify the controller as follow
[HttpPost]
public HttpResponseMessage Post([FromBody] LoginViewModel DATA) {
   using (appapidataEntities entities = new appapidataEntities())           
        string id = DATA.ID;
        string password = DATA.Password;
       // rest of the code
   }
}
Make sure the device is sending the data the service is waiting  (maybe adding a breakpoint if you are debugging from Android Studio before to make the request) and add a breakpoint in your controller to verify that the variable DATA has the correct values.
