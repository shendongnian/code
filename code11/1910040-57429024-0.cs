    public class Move : NetworkBehaviour
    {
        private void Start()
        {
            if (isLocalPlayer) return;
            // Here we closed the script which is not ours
            GetComponent<Move>().enabled = false;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                CmdComand();
            }
        }
    
        [Command]
        private void CmdComand()
        {
            // We give it to server
            RpcToClients();
        }
    
        [ClientRpc]
        private void RpcToClients()
        {
            // Here we do what we want to happen on all player
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5,ForceMode2D.Impulse);
        }
    }
