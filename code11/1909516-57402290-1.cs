    namespace VirtualOS {
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Socket : MonoBehaviour
    {
        // A socket child in a CustomObject that allows plugs to snap into it, informing
        // the CustomObject when that happens.
    
        [SerializeField] SocketPlugShape shape = SocketPlugShape.None;
        [SerializeField] AudioSource insertPlugSound = null;
        [SerializeField] AudioSource removePlugSound = null;
    
        Plug connectedPlug = null;
    
        Action<Plug> onPlugged = null;
        Action       onUnplugged = null;
        
        public void SetOnPlugged(Action<Plug> onPlugged)
        {
            this.onPlugged = onPlugged;
        }
    
        public void SetOnUnplugged(Action onUnplugged)
        {
            this.onUnplugged = onUnplugged;
        }
        
        public bool TryInsertPlug(Plug plug)
        {
            bool success = false;
            if (
                connectedPlug == null &&
                shape != SocketPlugShape.None &&
                plug.GetShape() == shape
            )
            {
                CustomObject customObject = plug.GetComponentInParent<CustomObject>();
                if (customObject != null)
                {
                    success = true;
                    
                    connectedPlug = plug;
                    customObject.transform.parent = transform;
                    
                    AnimatePlugTowardsUs(customObject);
                    
                    insertPlugSound.Play();
                    
                    Handable handable = GetComponentInParent<Handable>();
                    if (handable != null && handable.handHoldingMe != null)
                    {
                        handable.handHoldingMe.Vibrate(VibrationForce.Hard);
                    }
                    
                    if (onPlugged != null) { onPlugged(plug); }
                }
            }
            return success;
        }
        
        void AnimatePlugTowardsUs(CustomObject customObject)
        {
            Tweener tweener = customObject.GetComponent<Tweener>();
            if (tweener != null)
            {
                tweener.ReachTargetInstantly();
            }
            else
            {
                tweener = customObject.gameObject.AddComponent<Tweener>();
            }
            tweener.Animate(
                position: Vector3.zero, rotation: Vector3.zero, seconds: 0.1f,
                tweenType: TweenType.EaseInOut
            );
        }
        
        public void RemovePlug()
        {
            if (connectedPlug != null)
            {
                if (onUnplugged != null) { onUnplugged(); }
                
                CustomObject customObject = connectedPlug.GetComponentInParent<CustomObject>();
                customObject.transform.parent = null;
    
                connectedPlug = null;
                
                removePlugSound.Play();
            }
        }
        
        public SocketPlugShape GetShape()
        {
            return shape;
        }
    
    }
    
    }
