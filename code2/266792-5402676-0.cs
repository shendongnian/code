using myApp.Web.Models;
using myApp.Web.Services;
using System.ServiceModel.DomainServices.Client;
namespace myApp
{
    public partial class MainPage : UserControl
    {
	MyModelContext _context = new MyModelContext();	
    }
...
}
