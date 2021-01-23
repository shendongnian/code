    public class ContractController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult GetSignatories(Contract contract)
        {
            return Json(contract.CurrentVersion.Tokens.Select(x => x.User).ToList());
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult AddMe(Contract contract)
        {
            var user = contract.CreatedBy;
            return AddUserToContract(contract, new UserSummary(user));
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveMe(Contract contract)
        {
            var user = contract.CreatedBy;
            return RemoveUserFromContract(contract, new UserSummary(user));
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(Contract contract, UserSummary userSummary)
        {
            return AddUserToContract(contract, userSummary);
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUser(Contract contract, UserSummary userSummary)
        {
            return RemoveUserFromContract(contract, userSummary);
        }
    }
