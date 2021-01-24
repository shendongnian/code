    public class viewmodel : BaseViewModel {
        public viewmodel() {
            
            RemoveSubjectCommand = new RelayCommand<MyItemModel>((p) => { return true; }, (OnRemoveSubject));
            //assuming RoutePlanResource initialized and populated
        }
        public ObservableCollection<MyItemModel> RoutePlanResource {
            //assuming boilerplate getter and setter with notification
        }
        public ICommand RemoveSubjectCommand { get; set; }
        private void OnRemoveSubject(MyItemModel item) {
            RoutePlanResource.Remove(item);
            //...
        }
    }
