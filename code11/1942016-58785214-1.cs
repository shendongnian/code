    Class MyClass
    {
        string[] speaking = null;
        private void DoMethod()
        {
            speaking = System.Convert.ToString(Dspeaker.SelectedItem).Split(' ');
        }
        private void CheckSpeaking()
        {
            if (speaking != null && speaking.Length > 0)
            {
                // Do Stuff
            }
        }
    }
