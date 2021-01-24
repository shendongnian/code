        public class MemberInfoController : Controller
        {
            IMemberDetails details;
            public MemberInfo(IMemberDetails det)
            {
                details = det;
            }
        }
    // further code
