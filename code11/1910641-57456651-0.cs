    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
 
    public class Slot : MonoBehaviour, IDropHandler {
	public GameObject object1;
	public GameObject object2;
	public GameObject item 
	{
		get {
			if (transform.childCount > 0) 
				{
					return transform.GetChild (0).gameObject;
				}
				return null;
		    }
	}
	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log ("ondrop");
		object1.transform.parent = object2.transform;
		
	}
	#endregion
    }
