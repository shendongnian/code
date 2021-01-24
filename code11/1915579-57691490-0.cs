    public class Example : MonoBehaviour
    {
        public TextMeshProUGUI text;
    
        public string LastClickedWord;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var charIndex = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, null);
    
                if (charIndex != -1)
                {
                    LastClickedWord = text.textInfo.wordInfo[charIndex].GetWord();
    
                    Debug.Log("Clicked on " + LastClickedWord);
                }
            }
        }
    }
    
