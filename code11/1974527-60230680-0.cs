    public class ExampleClass : MonoBehaviour
    {
        public int maxLines = 8;
        private Queue<string> queue = new Queue<string>();
        private string currentText = "";
    
        void OnEnable()
        {
            Application.logMessageReceivedThreaded += HandleLog;
        }
    
        void OnDisable()
        {
            Application.logMessageReceivedThreaded -= HandleLog;
        }
    
        void HandleLog(string logString, string stackTrace, LogType type)
        {
            // Delete oldest message
            if (queue.Count >= maxLines) queue.Dequeue();
  
            queue.Enqueue(message);
  
            var builder = new StringBuilder();
            foreach (string st in queue)
            {
                builder.Append(st).Append("\n");
            }
        
        currentText = builder.ToString();
        }
        void OnGUI()
        {
            GUI.Label(
               new Rect(
                   5, // x, left offset
                   Screen.height - 150, // y, bottom offset
                   300f, // width
                   150f), 
               currentText, // the display text
               GUI.skin.textArea); // height, text, Skin features
        }
    }
