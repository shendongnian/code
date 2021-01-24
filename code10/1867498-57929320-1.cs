    using Oculus.Platform;
    using Oculus.Platform.Models;
    // ...
    Net.SetConnectionStateChangedCallback((Message<NetworkingPeer> message) => {
        if (message.Data.State == PeerConnectionState.Closed) {
            Debug.Log("The user MOST LIKELY quit the app.");
        }
    });
