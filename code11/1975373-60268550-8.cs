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
        
        #if UNITY_EDITOR
        // in order to catch all editor own key events on runtime
        // you will still get the warning "You have to exit playmode in order to save"
        // but at least this makes the Hello print anyway. Couldn't figure out how to catch the key completely before Unity handles it
        private void OnGUI()
        {
            var e = Event.current;
            e.Use();
        }
        #endif
    }
    
