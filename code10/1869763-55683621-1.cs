    public class PlayerSetup : NetworkBehaviour
    {
        [SerializeField]
        Behaviour[] componentsToDisable; // disable some scripts for multiplayer
    
        void Start()
        {
            if (!isLocalPlayer)
            {
                foreach(var component in componentsToDisable)
                {
                    component.enabled = false;
                }
            }
            else
            {
                MainCameraProvider.MainCamera.gameObject.SetActive(false);
            }
        }
    
        private void OnDisable()
        {
            MainCameraProvider.MainCamera.gameObject.SetActive(true);
        }
    }
