    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class InputFieldDeselect : MonoBehaviour, IPointerClickHandler, IDeselectHandler
    {
        InputField inputField;
        Color startColor;
    
        void Start()
        {
            inputField = GetComponent<InputField>();
            startColor = inputField.selectionColor;
            inputField.selectionColor = Color.clear;
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            inputField.selectionColor = inputField.caretPosition == 0 ? Color.clear : startColor;
        }
    
        public void OnDeselect(BaseEventData eventData)
        {
            inputField.selectionColor = Color.clear;
        }
    }
