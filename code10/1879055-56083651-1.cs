    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PurchaseScript : MonoBehaviour
    {
        public void BuyComplete(UnityEngine.Purchasing.Product product)
        {
    		PlayerPrefs.SetInt("wichAvatarIsOn", product.id); //I added it as product.id for this example, you will need to decide how you will do it. 
            Application.LoadLevel("Scene/Room3");
        }
    
        public void BuyFailed(UnityEngine.Purchasing.Product product, UnityEngine.Purchasing.PurchaseFailureReason fa)
        {
            Debug.Log("PURCHASE FAILED");
        }
    }
