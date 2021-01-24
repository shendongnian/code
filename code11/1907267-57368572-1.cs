    public class ScreenshotCamera : MonoBehaviour
    {
    	public bool m_TakeScreenshot;
    	public Texture2D m_OutputTexture;
    
    	void OnPostRender()
    	{
    		if (m_TakeScreenshot)
    		{
    			m_TakeScreenshot = false;
    
    			//Take screenshot
    			if (m_OutputTexture == null)
    				m_OutputTexture = new Texture2D(Screen.width, Screen.height);
    			m_OutputTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    			m_OutputTexture.Apply();
    
    			//Get all pixels, count green pixels
    			var pixels = m_OutputTexture.GetPixels(0, 0, m_OutputTexture.width, m_OutputTexture.height);
    			int greenPixels = 0, otherPixels = 0;
    			foreach (var color in pixels)
    			{
    				//green
    				if (color.g > 0.8f && color.r < 0.1f && color.b < 0.1f)
    					greenPixels++;
    				//not black
    				else if (color.r > 0.1f || color.g > 0.1f || color.b > 0.1f)
    					otherPixels++;
    			}
    		}
    	}
    }
