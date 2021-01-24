    public class ProgressEventArgs : EventArgs
    {
        private float m_progress;
        public ProgressEventArgs(float progress)
        {
            m_progress = progress;
        }
        public float Progress => m_progress;
    }
