    public sealed class PlayerData
    {
        //Data related to the Player (possibly immutable)
    }
    public sealed class Player : INotifyPropertyChanged
    {
        private PlayerData _data;
        //Mirror properties for information in data
        //Other functionality
        public void ChangeData(PlayerData newData)
        {
            _data = newData;
            //Trigger OnPropertyChanged(null) here to invalidate public state
        }
    }
