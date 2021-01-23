    public class SharedController : Controller
        [ChildActionOnly]
        public ViewResult SideBar() {
            return new PartialView(new SideBarModel());
        }
    }
