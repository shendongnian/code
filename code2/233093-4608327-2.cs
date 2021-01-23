    public class ProgramController
    {
        IProgramView _view;
        public ProgramController(IProgramView view)
        {
            // now the controller has access to _view.FirstName
            // to push data to and get data from
            _view = view;
        }
    }
