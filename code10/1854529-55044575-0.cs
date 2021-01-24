        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using GoogleMobileAds.Api;
        
        public class MostrarIntersticial : MonoBehaviour {
        
        private InterstitialAd interstitial;
    
            // Inicialización del intersticial
            private void Start () {
        
                  #if UNITY_ANDROID
                     string adUnitId = "ca-app-pub-3940256099942544/1033173712";
                 #elif UNITY_IPHONE
                     string adUnitId = "ca-app-pub-3940256099942544/4411468910";
                 #else
                     string adUnitId = "unexpected_platform";
                 #endif
    
    // rest of your code
