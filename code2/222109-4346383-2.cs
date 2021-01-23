    public class AddressesController : BaseController<AddressRepository>
    {
        public AddressesController() 
            : base(new AddressRepository(), new AddressModelMapper())
        {
        }
        public ActionResult Addresses(int id)
        {
            return View(Respository.GetAllByUserId(id));
        }
    }
