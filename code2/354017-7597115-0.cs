    [Subject(typeof (HomeController))]
    public class when_invalid_page_is_requested : SomeControllerSpec
    {
        Because of = () => result = Controller.PageNotFound();
        It should_set_status_code_to_404 = 
            () => HttpResponse.VerifySet(hr => hr.StatusCode = 404);
    }
    public abstract class SomeControllerSpec
    {
        protected static HomeController Controller;
        protected static Mock<ControllerContext> ControllerContext;
        protected static Mock<HttpResponseBase> HttpResponse;
        Establish context = () =>
        {
            ControllerContext = new Mock<ControllerContext>();
            HttpResponse = new Mock<HttpResponseBase>();
            ControllerContext.SetupGet(cc => cc.HttpContext.Response)
                             .Returns(HttpResponse.Object);
            Controller = new HomeController
                             {
                                 ControllerContext = ControllerContext.Object
                             };
        };
    }
