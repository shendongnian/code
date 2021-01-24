    public interface IMainRepository<TForm> where TForm : IMyForm, class
    {
        TForm GetForm();
    }
    public class SecondRepository : IMainRepository<SecondForm>
    {
        public SecondForm GetForm() 
        {
            var SecondForm form = new SecondForm();
            //Do stuff...
            return form;
        }
    }
    public class FormController : ApiController 
    {
        private readonly IMainRepository<FirstForm> firstFormRepository;
        private readonly IMainRepository<SecondForm> secondFormRepository;
        // etc.
    }
