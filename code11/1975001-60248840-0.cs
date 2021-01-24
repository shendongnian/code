class GameSettings : NetworkBehaviour {
 [SyncVar(hook=nameof(FragsRequiredAmountSyncVarChanged))] private int _fragsRequiredToWinSyncVar = 20;
 public void ChangeFragsRequiredToWin(int newAmount) {
  if (!isServer) {
   Debug.LogError("Sync vars can only change on the server!");
   return;
  }
  _fragsRequiredToWinSyncVar = newAmount;
 }
 private void FragsRequiredAmountSyncVarChanged(int newAmount)
 {
  Debug.Log($"Frag requirement changed to {newAmount}");
 }
}
I've also included an example on how to attach hooks when the `SyncVar` changes; I'm pretty sure it gets called on both the server and the client, but my memory might fail me since it's been quite a while since I last used UNET.
