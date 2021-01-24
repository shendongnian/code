    public class PlayerMovement : MonoBehaviour{
    
        Vector3[] points = new Vector3[10000];
        public float speed = 1f;
        private int curSourceIndex = 0;
        private int goalIndex = 0; // no goal
    
        private void Update()
        {
            if (goalIndex != curSourceIndex)
            {
                MoveBus();
            }
        }
 
        private void MoveBus()
        {
            int step = goalIndex > curSourceIndex ? 1 : -1;
            float distLeft = speed * Time.deltaTime;
    
            while (distLeft > 0 && curSourceIndex != goalIndex)
            {
                Vector3 curTarget = points[curSourceIndex + step];
                Vector3 curPos = transform.position;
                Vector3 newPos = Vector3.MoveTowards(curPos, curTarget, distLeft);
     
                distLeft -= (newPos-curPos).magnitude;
    
                if (newPos == curTarget) 
                {
                    // Leave trace at each point reached
                    LeaveTrace(newPos)
                    
                    curSourceIndex += step;
                }
 
                transform.position = newPos;
            }
        }
        public void SetGoalIndex(int index)
        {
            if (index < 0 || index >= points.length) return; // or throw/log etc here
            // Do any appropriate modification to curSourceIndex
            if (points[curSourceIndex] != curPos) 
            {
                // If we were going up but we're going down (or back to where we were), 
                // increase source index
                if (goalIndex > curSourceIndex && index <= curSourceIndex) 
                { 
                    curSourceIndex +=1;
                }
                // if vice versa, decrease source index
                else if (goalIndex < curSourceIndex && index >= curSourceIndex)  
                {
                    curSourceIndex -=1;
                }   
            }
            goalIndex = index;
        }
     
        void LeaveTrace(Vector3 pos)
        {
            // leave a trace at the pos location
        }
    }
