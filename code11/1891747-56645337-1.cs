    using UnityEngine;
    
    [RequireComponent(typeof(RectTransform))]
    public class VRUIItem : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        private RectTransform _rectTransform;
    
        private void OnEnable()
        {
            ValidateCollider();
        }
    
        private void Update()
        {
            ValidateCollider();
        }
    
        private void OnValidate()
        {
            ValidateCollider();
        }
    
        private void ValidateCollider()
        {
            if (!_rectTransform) _rectTransform = GetComponent<RectTransform>();
    
            if (!_boxCollider) _boxCollider = GetComponent<BoxCollider>();
            if (!_boxCollider) _boxCollider = gameObject.AddComponent<BoxCollider>();
    
            _boxCollider.size = _rectTransform.rect.size;
        }
    }
    
