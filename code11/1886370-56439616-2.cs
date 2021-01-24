    using Microsoft.MixedReality.Toolkit.Input;
    using UnityEngine;
    
    public class Object: MonoBehaviour, IMixedRealityFocusHandler
    {
        public GameManager _gameManager;
    
        public void OnFocusEnter(FocusEventData eventData)
        {
            Debug.Log("Focus ON: " + gameObject);
            _gameManager.SetFocussedObject(gameObject);
        }
    
        public void OnFocusExit(FocusEventData eventData)
        {
            Debug.Log("Focus OFF: " + gameObject);
            _gameManager.ResetFocussedObject();
        }
    }
