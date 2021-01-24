	public class PlaceItems : MonoBehaviour
	{
		public GameObject wall;
		void Update()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
					Instantiate(wall, hit.point, Quaternion.identity);
			}
		}
	}
