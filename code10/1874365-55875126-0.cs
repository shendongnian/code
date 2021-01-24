public class Camera
{
    public Camera()
    {
        zoomingIn = true;
        m_Weight0 = 100;
        m_Weight1 = 0;
        m_Weight2 = 0;
    }
    public bool zoomingIn { get; set; }
    public float m_Weight0 { get; set; }
    public float m_Weight1 { get; set; }
    public float m_Weight2 { get; set; }
    public void HandleCameraSwitching(float newWeight)
    {
        if (m_Weight0 == 100) zoomingIn = true;
        else if (m_Weight2 == 100) zoomingIn = false;
        if (zoomingIn)
        {
            if (m_Weight0 == 100 || (m_Weight0 > 0 && m_Weight1 > 0))
            {
                m_Weight0 = 100 - newWeight;
                m_Weight1 = newWeight;
            }
            else if (m_Weight1 == 100 || (m_Weight1 > 0 && m_Weight2 > 0))
            {
                m_Weight1 = 100 - newWeight;
                m_Weight2 = newWeight;
            }
        }
        else
        {
            if (m_Weight2 == 100 || (m_Weight2 > 0 && m_Weight1 > 0))
            {
                m_Weight2 = 100 - newWeight;
                m_Weight1 = newWeight;
            }
            else if (m_Weight1 == 100 || (m_Weight1 > 0 && m_Weight0 > 0))
            {
                m_Weight1 = 100 - newWeight;
                m_Weight0 = newWeight;
            }
        }
    }
}
`bool zoomingIn` changes when A or C equals 100
