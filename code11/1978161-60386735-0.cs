	public class UIShipItem<T> : MonoBehaviour where T : BuildingBaseObject
	{
		T buildingObject;
		public T BuildingObject
		{
			get
			{
				return buildingObject;
			}
			set
			{
				buildingObject = value;
				gameObject.GetComponent<Image>().sprite = buildingObject.sprite;
			}
		}
	}
