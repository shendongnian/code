    using UnityEngine;
    using UnityEngine.UI;
    
    public class CustomInputField : InputField
    {
        private int oldCaretPosition;
    
        public override void Rebuild(CanvasUpdate update)
        {
            base.Rebuild(update);
            oldCaretPosition = caretPosition;
        }
    
        protected override void LateUpdate()
        {
            base.LateUpdate();
            if (Input.GetKeyDown(KeyCode.End))
            {
                int newLineIndex = FindEndOfLine(oldCaretPosition);
                caretPosition = newLineIndex;
            }
        }
    
        private int FindEndOfLine(int startIndex)
        {
            for (int i = startIndex; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    return i;
                }
            }
            return text.Length;
        }
    }
