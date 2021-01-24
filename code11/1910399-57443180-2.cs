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
        }
        void Start() {
            FitButtonWidthToText();
        }    
        public void FitButtonWidthToText() {
            int widthOfTheText= 0;
            CharacterInfo characterInfo;
            foreach(char c in buttonText.text) {
                buttonText.font.GetCharacterInfo(c, out characterInfo, buttonText.fontSize);
                widthOfTheText += characterInfo.advance;
            }
            buttonTransform.sizeDelta = new Vector2(widthOfTheText, buttonTransform.sizeDelta.y);
        }
    }
