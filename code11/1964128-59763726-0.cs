csharp
public class ToggleToggle : MonoBehaviour {
    public Toggle toggle1;
    public Toggle toggle2;
    public GameObject cube;
    public GameObject cube2;
    public Toggle[] toggles;
    public GameObject[] cubes;
    public static Toggle firstTickedToggle;
    void Start ()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SetActive(false);
        }
    }
    public void OnToggleClick(Toggle toggle)
    {
        if (toggle.enabled)
        {
            if (firstTickedToggle == null)
                firstTickedToggle = toggle;
            int toggleIndex = 0; // Index of the first clicked toggle
            // Check if all toggles are ticked
            for (int i = 0; i < toggles.Length; i++)
            {
                // If one is not ticked
                if (!toggles[i].enabled)
                    return;
                if (toggles[i] == firstTickedToggle)
                    toggleIndex = i;
            }
            // Here all toggles are ticked
            cubes[toggleIndex].SetActive(true);
        }
        else
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                // If one toggle is still ticked, don't do anything
                if (toggles[i].enabled)
                    return;
            }
            // If all toggles are unticked, remove the reference to the first ticked
            firstTickedToggle = null;
        }
    }
}
[All toggles need a `OnValueChanged`](https://imgur.com/a/K5EqVU1)
