public IActionResult Login(UserDTO user)
{
    ...
    
    // after validating and login success
    var cookie = new HttpCookie("response", user);
    cookie.Expires = DateTime.Now.AddDays(30);
    Response.Cookies.Add(cookie); // use here Response.Cookies not Request.Cookies
    ...
    return View();
}
---
public IActionResult Index()
{
    var cookie = HttpContext.Request.Cookies["response"] as UserDTO; // must be the same type when set its value
    ViewData["Cookie"] = cookie;
    return View();
}
and in View
var computername = HttpContext.Request.Cookies["response"].Value as UserDTO; // to prevent casting exception .. will return null if cast faild
if(computername != null) 
{
    computername.Name;// will return Kim 
    computername.UserId;// will return 53 
}
