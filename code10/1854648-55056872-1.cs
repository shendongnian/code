    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    
        public class MyTestClass : MonoBehaviour,IPointerExitHandler,IPointerDownHandler
        {
        
        
            bool _isFirstButtonPressed = false;
            bool _isSecondButtonPressed = false;
        
            Event keyboardEvent = new Event();
        
            public Text firstKeyText;
            public Text secondKeyText;
            private string key;
        
            public Button _button;
        
        
        
        
        
           
        
        
        
            public void OnPointerDown(PointerEventData eventData)
            {
        
                if (eventData.selectedObject.name == "FirstButton")
                {
                    _isFirstButtonPressed = true;
                }
        
                if (this.gameObject.name == "SecondButton")
                {
                    _isSecondButtonPressed = true;
                }
        
            }
        
            public void OnPointerExit(PointerEventData eventData)
            {
                if (this.gameObject.name == "FirstButton")
                {
                    _isFirstButtonPressed = false;
                }
        
                if (this.gameObject.name == "SecondButton")
                {
                    _isSecondButtonPressed = false;
                }
            }
        
        
        
            void OnGUI()
                {
                    Event currentEvent = Event.current;
        
                if (currentEvent.isKey)
                    {
        
                    if (currentEvent.keyCode.ToString() != "None")
                        {
                            keyboardEvent = currentEvent;
                            key = keyboardEvent.keyCode.ToString();
        
        
                        if (_isFirstButtonPressed) {
                            firstKeyText.text = key;
                        }
        
                        if (_isSecondButtonPressed)
                        {
                            secondKeyText.text = key;
                        }
        
                    }
                    }
                }
