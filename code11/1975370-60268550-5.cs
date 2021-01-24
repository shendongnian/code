    public class ShortCutTester : MonoBehaviour
    {
        // This youc an now call via the context menu of the someShortCut field in the Inspector
        [ContextMenuItem("Set Shortcut", nameof(SetSomeShortCut))]
        public ShortCut someShortCut;
    
        private void SetSomeShortCut()
        {
            ShortKeyDialog.ShowDialog(someShortCut, result =>
            {
                // mark as dirty and provide undo/redo funcztionality
                Undo.RecordObject(this, "Change someShortCut");
                someShortCut = result;
            });
        }
    
        private void Update()
        {
            if (someShortCut.IsDown)
            {
                Debug.Log("Hello!");
            }
        }
    }
    
