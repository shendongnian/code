    public  class EquipmentScreenViewModel
    {
        public string SelectedEquipmentRego { get; set; }
        public ObservableCollection<Equipment> AllEquipments { get; set; }
        private ICollectionView _allEquipCollection = null;
        public ICollectionView AllEquipCollection
        {
            get
            {
                if (_allEquipCollection == null && AllEquipments != null)
                {
                    _allEquipCollection = CollectionViewSource.GetDefaultView(AllEquipments);
                }
                return _allEquipCollection;
            }
        }
    }
