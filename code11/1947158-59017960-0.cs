    public class MainWindowViewModel : BaseViewModel, ITableResponseHandler
    {
        public void HandleResponse(IEnumerable<Entity> allEntities) { }
    }
    public interface ITableResponseHandler
    {
        void HandleResponse(IEnumerable<Entity> allEntities);
    }
    public class MyActor : ReceiveActor
    {
        public MyActor(ITableResponseHandler viewModel) 
        {
            this.Receive<GetAllEntitiesResponse>(this.HandleGetAllEntitiesResponseReceived);
        }
        private void HandleGetAllEntitiesResponseReceived(GetAllTablesResponse obj)
        {
            this._ViewModel.HandleTablesResponse(obj.Result);
        }
    }
