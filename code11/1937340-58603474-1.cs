    public class Example : MonoBehaviour
    {
        void Start()
        {
        	Cooldown(2, () => RecyclePlatform(gameObject));
        }
        
        void RecyclePlatform(GameObject Platform)
        {
        	Platform.transform.position = new Vector3(0, 0, _zedOffset);
        	_zedOffset += 4;
    	}
    }
