    public class TestController : Controller
    {
        public ActionResult Index()
        {
            TestViewModel vm = new TestViewModel {ChangeMe = "a1", DontChangeMe = "b1"};
            ProtectedPropertyAttribute.LockObject(vm);
            return View(vm);
        }
        public string Submit(TestViewModel vm)
        {
            string errMessage;
            return !validate(out errMessage) ? "you are a baaad, man." + errMessage : "you are o.k";
        }
        private bool validate(out string errormessage)
        {
            if (ModelState.IsValid)
            {
                errormessage = null;
                return true;
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, ModelState> pair in ModelState)
            {
                sb.Append(pair.Key);
                sb.Append(" : <br/>");
                foreach (ModelError err in pair.Value.Errors)
                {
                    sb.Append(" - ");
                    sb.Append(err.ErrorMessage);
                    sb.Append("<br/>");
                }
                sb.Append("<br/>");
            }
            errormessage = sb.ToString();
            return false;
        }
    }
