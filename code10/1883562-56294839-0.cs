void OnTriggerStay2D(Collider2D other)
{
	if (Input.GetKeyDown(interactableKey))
	{
		chestInventoryUI.SetActive(true);
		Time.timeScale = 0.0f;
	}
	if (Input.GetKeyUp(interactableKey))
	{
		chestInventoryUI.SetActive(false);
		Time.timeScale = 1.0f;
	}
}
  [1]: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerStay2D.html
