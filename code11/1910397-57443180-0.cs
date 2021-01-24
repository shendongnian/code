    using UnityEngine;
    using UnityEngine.UI;
    
    //Just to make sure its put on a button
    [RequireComponent(typeof(Button))]
    public class FitButtonSizeToText : MonoBehaviour
    {
        RectTransform buttonTransform;
        Text buttonText;
    
        void Awake() {
            buttonTransform = GetComponent<RectTransform>();
            buttonText = GetComponentInChildren<Text>();
    
            FitButtonWidthToText();
        }
    
        public void FitButtonWidthToText() {
            int length = 0;
            CharacterInfo characterInfo;
            foreach(char c in buttonText.text) {
                buttonText.font.GetCharacterInfo(c, out characterInfo, buttonText.fontSize);
                length += characterInfo.advance;
            }
            buttonTransform.sizeDelta = new Vector2(length, buttonTransform.sizeDelta.y);
        }
    }
