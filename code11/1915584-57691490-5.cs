    public class Example : MonoBehaviour
    {
        public TextMeshProUGUI text;
    
        public string LastClickedWord;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var wordIndex = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, null);
    
                if (wordIndex != -1)
                {
                    LastClickedWord = text.textInfo.wordInfo[wordIndex].GetWord();
    
                    Debug.Log("Clicked on " + LastClickedWord);
                }
            }
        }
    }
