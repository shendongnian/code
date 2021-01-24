    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class Interactable3D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Color normalColor;
        public Color hoverColor;
    
        private Renderer renderer;
    
        private void Awake()
        {
            renderer = GetComponent<Renderer>();
            renderer.material.color = normalColor;
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log(" ENTEREd!");
            transform.localScale *= 1.2f;
            renderer.material.color = hoverColor;
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("EXIT!");
            transform.localScale /= 1.2f;
            renderer.material.color = normalColor;
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("CLICKED!");
        }
    }
