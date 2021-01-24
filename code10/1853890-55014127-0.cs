    public class MyVRController
    {
        public event EventHandler OnPickedup;
        public event EventHandler OnLetGo;
        private bool HasObject = false;
        ...
        private void SuccessfullyPickedUp(GameObject pickedUpGO)
        {
            if(OnPickedUp != null)
            {
                HasObject = true;
                OnPickedUp(pickedUpGO, null);
            }
        }
        ...
        private void OnLetGo()
        {
            if(OnLetGo != null)
            {
                HasObject = false;
                OnLetGo(this, null);
            }
        }
        ...
    }
