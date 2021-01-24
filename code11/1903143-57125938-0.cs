unity
  (using System.Linq;)
void Update() {
	var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
	foreach (var key in allKeys) {
		if (Input.GetKeyDown(key)) {
			Debug.Log(key + " was pressed.");
		}
	}
}
