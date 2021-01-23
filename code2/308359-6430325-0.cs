    static class Program
    {
        static void Main()
        {
            TextTranstition transition = new TextTranstition();
            transition.TransitionFinished += TransitionTicked;
            transition.TransitionTicked += TransitionTicked;
            transition.StartTransition("AmazingWordTransition", "MyNewWordAppearing", 100);
            Thread.CurrentThread.Join();
            Console.ReadKey();
        }
        public static void TransitionTicked(object sender, TranstitionEventArg e)
        {
            Console.Clear();
            Console.Write(e.TransitionText);
        }
    }
    public class TranstitionEventArg : EventArgs
    {
        private readonly string transitionText;
        public string TransitionText { get { return this.transitionText; } }
        
        public TranstitionEventArg(string transitionText)
        {
            this.transitionText = transitionText;
        }
    }
    public class TextTranstition
    {
        private struct StartInfo
        {
            public StartInfo(string initialText, string finalText, int timeStep)
            {
                this.initialText = initialText;
                this.finalText = finalText;
                this.timeStep = timeStep;
            }
            private readonly string initialText;
            public string InitialText { get { return this.initialText; } }
            private readonly string finalText;
            public string FinalText { get { return this.finalText; } }
            private readonly int timeStep;
            public int TimeStep { get { return this.timeStep; } }
        }
        public EventHandler<TranstitionEventArg> TransitionFinished;
        public EventHandler<TranstitionEventArg> TransitionTicked;
        
        public void StartTransition(string initialText, string finalText, int timeStep)
        {
            StartInfo startInfo = new StartInfo(initialText, finalText, timeStep);
            Thread t = new Thread(startTransition);
            t.Start(startInfo);
        }
        private void startTransition(object info)
        {
            StartInfo startInfo = (StartInfo)info;
            string initialText = startInfo.InitialText;
            string finalText = startInfo.FinalText;
            if (initialText.Length < finalText.Length)
            {
                initialText = initialText.PadRight(finalText.Length);
            }
            if (TransitionTicked != null) TransitionTicked(this, new TranstitionEventArg(initialText));
            while ((initialText = transition(initialText, finalText)) != finalText)
            {
                Thread.Sleep(startInfo.TimeStep);
                if (TransitionTicked != null) TransitionTicked(this, new TranstitionEventArg(initialText));
            }
            if (TransitionFinished != null) TransitionFinished(this, new TranstitionEventArg(finalText));
        }
        private string transition(string initialText, string finalText)
        {
            StringBuilder b = new StringBuilder(finalText.Length);
            for (int i = 0; i < finalText.Length; i++)
            {
                char c = initialText[i];
                int charCode = (int)c;
                if (c != finalText[i])
                {
                    if (charCode == 122 || charCode==32) charCode = 65;
                    else if (charCode == 90) charCode = 97;
                    else
                    {
                        charCode += 1;
                    }
                }
                b.Append((char)charCode);
            }
            return b.ToString();
        }
    }
