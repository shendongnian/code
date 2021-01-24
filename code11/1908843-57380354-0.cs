    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Photon.Pun;
    using Photon.Realtime;
    using ExitGames.Client.Photon;
    
    public class PhotonRoomPoller : MonoBehaviourPunCallbacks
    {
        // Creates a second Photon peer to poll online room counts info.
        // A second peer is necessary as one otherwise while in a Room can't join
        // the Lobby, needed to get the room list. API at
        // doc-api.photonengine.com/en/pun/v2/class_photon_1_1_realtime_1_1_load_balancing_client.html
    
        Action<List<RoomInfo>> callback = null;
        LoadBalancingClient client = null;
    
        public void GetRoomsInfo(Action<List<RoomInfo>> callback)
        {
            this.callback = callback;
            
            client = new LoadBalancingClient();
            client.AddCallbackTarget(this);
            client.StateChanged += OnStateChanged;
            client.AppId = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime;
            client.AppVersion = PhotonNetwork.NetworkingClient.AppVersion;
            client.ConnectToRegionMaster("us");
        }
    
        void Update()
        {
            if (client != null)
            {
                client.Service();
            }
        }
    
        void OnStateChanged(ClientState previousState, ClientState state)
        {
            // Debug.Log(state);
            if (state == ClientState.ConnectedToMaster)
            {
                client.OpJoinLobby(null);
            }
        }
        
        public override void OnRoomListUpdate(List<RoomInfo> infos)
        {
            if (callback != null)
            {
                callback(infos);
            }
            client.Disconnect();
        }
    
    }
