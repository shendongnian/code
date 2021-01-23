    public class AdministrationController : BaseController {
        public ActionResult Customer(
            int CustomerId) {
            return this.View(this.CustomerProvider.GetView(CustomerId));
        }
        public AciontResult Customers() {
            return this.Veiw(this.CustomerProvider.GetAllView(CustomerId));
        }
        public ActionResult CustomerAddresses(
            int CustomerId,
            Address Address) {
            if (ModelState.IsValid) {
                this.CustomerProvider.AddAddressAndSave(CustomerId, Address);
            };
            return this.RedirectToAction("Customer", new {
                CustomerId = CustomerId
            });
        }
        public ActionResult Employee(
            int EmployeeId) {
            return this.View(this.EmployeeProvider.GetView(EmployeeId));
        }
        public ActionResult Employees() {
            return this.View(this.EmployeeProvider.GetAllView());
            //  OR
            //  return this.View(this.EmployeeProvider.GetActiveView());
            //  OR
            //  return this.Veiw(this.EmployeeProvider.GetInactiveView());
            //  ETC...
            //  All of these return the exact same object, just filled with different data
        }
        public RedirectToRouteResult EmployeeAddresses(
            int EmployeeId,
            Address Address) {
            if (ModelState.IsValid) {
                this.EmployeeProvider.AddAddressAndSave(EmployeeId, Address);
                //  I also have AddAddress in case I want to queue up a couple of tasks
                //  before I commit all changes to the data context.
            };
            return this.RedirectToAction("Employee", new {
                EmployeeId = EmployeeId
            });
        }
    }
