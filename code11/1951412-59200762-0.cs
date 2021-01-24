c#
using UnityEngine;
public class globalControl : MonoBehaviour
{
    public Component[] renderers;
    void Start()
    {
        prefabsParent = GameObject.Find("PrefabsParent");
        renderers = prefabsParent.GetComponentsInChildren<Renderer>();
    }
    /// Use this method when you wish to change the color 
    void ChangeColor(Color color)
    {
        foreach (var renderer in renderers)
            renderer.material.color = color;
    }
    void Update()
    {
        [...]
        if (Input.GetKeyDown("r"))
        {
            ChangeColor(Color.red);
        } else if (Input.GetKeyDown("b"))
        {
            ChangeColor(Color.blue);
        } else if (Input.GetKeyDown("g"))
        {
            ChangeColor(Color.green);
        }
    }
}
Hope this will help, Good luck ;)
