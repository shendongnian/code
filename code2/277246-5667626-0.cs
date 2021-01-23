    public class Otherclass{
        bool docontinue = true;
        public void postMessage(string input)
        {
             docontinue = true;
        }
    
        public void wait()
        {
              while(!docontinue)
              {
              }
        }
    }
