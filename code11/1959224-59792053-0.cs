    namespace Game
    {
        [Findable(R.S.GameObject.GameHasEndedFormallyEventChannel)]
        public class GameHasEndedFormallyEventChannel : EventChannel
        {
            public event EventHandler OnGameEnded;
            
            public override void Publish()
            {
                if (OnGameEnded != null)
                {
                    OnGameEnded();
                } 
            }
        }
    }
