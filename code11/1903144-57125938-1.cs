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
As for the switch statement, it's not possible and not worth it if you're searching for specific input.    
Would be best to just use `if-else` statements.
