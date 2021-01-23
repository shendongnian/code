    public abstract class ContractorControllerBase<T> : Controller where T : IContractor { 
        public ViewResult New() { 
            var vNewModel = new NewViewModel<T>(); 
            return View(vNewModel); 
        } 
    } 
    
    public class FakeContractorController : ContractorControllerBase<FakeContractor> {
    }
