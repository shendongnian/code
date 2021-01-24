    public class BezierCurve
    {
        //Starts following bezier curve.
        public void StartFollow()
        {
            //some code here.
        }
    }
    
    public class BezierCurveBatch : MonoBehaviour
    {
        [SerializeField]
        List<BezierCurve> m_lstChildren;
    
        [SerializeField]
        float m_delayStartCurve = 10;
        float m_timeLeftToStartNextChild = 0;
    
        bool m_isRunBatchCurve = false;
        
        /// <summary>
        /// Start batch follow after each interval.
        /// </summary>
        public void StartBatch()
        {
            m_isRunBatchCurve = true;
        }
    
        private void Update()
        {
            if (!m_isRunBatchCurve)
                return;
    
            m_timeLeftToStartNextChild -= Time.deltaTime;
            if (m_timeLeftToStartNextChild <= 0.0f)
            {
                if (m_lstChildren.Count > 0) //if we have children left.
                {
                    BezierCurve l_bCurveToStart = m_lstChildren[0];     //Getting top object.
                    m_lstChildren.RemoveAt(0);                          //removing top object.
                    l_bCurveToStart.StartFollow();                      //Start follow bezier curve
                    m_timeLeftToStartNextChild = m_delayStartCurve;     //resetting time.
                }
                
                if (m_lstChildren.Count == 0)       //After processing last object, check if need to continue for next object.
                    m_isRunBatchCurve = false;
            }
        }
    }
