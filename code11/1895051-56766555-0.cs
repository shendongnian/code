csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HumanBodyPart
{
    public string EnglishTitle;
    public List<HumanBodyPart> SubParts;
}
public class Script : MonoBehaviour 
{
    bool shouldShowSubparts = false;
    [SerializeField]
    Text text;
    private void ShowSubPartsOnClick(float x, float y, float widthLABEL, float heigth, HumanBodyPart bodyPart)
    {
        x = x + 14;
        for (int i = 0; i < bodyPart.SubParts.Count; i++)
        {
            Debug.Log(bodyPart.SubParts[i].EnglishTitle);
            y = y + 14;
            GUI.Label(new Rect(x + 14, y, widthLABEL, heigth), bodyPart.SubParts[i].EnglishTitle);
            if (GUI.Button(new Rect(x, y, 14, heigth), "+"))
            {
                ShowSubPartsOnClick(x, y, widthLABEL, heigth, bodyPart.SubParts[i]);
            }
        }
    }
    private void OnGUI()
    {
        HumanBodyPart testBodyPart = new HumanBodyPart();
        testBodyPart.EnglishTitle = "BodyPart";
        testBodyPart.SubParts = new List<HumanBodyPart>();
        HumanBodyPart subBodyPart = new HumanBodyPart();
        subBodyPart.EnglishTitle = "SubBodyPart";
        subBodyPart.SubParts = new List<HumanBodyPart>();
        testBodyPart.SubParts.Add(subBodyPart);
        GUI.Label(new Rect(text.transform.position.x + 30, text.transform.position.y, 200, 20), testBodyPart.EnglishTitle);
        if (GUI.Button(new Rect(text.transform.position.x, text.transform.position.y, 20, 20), "+"))
        {
            shouldShowSubparts = true;
        }
        if (shouldShowSubparts)
        {
            ShowSubPartsOnClick(text.transform.position.x, text.transform.position.y, 200, 20, testBodyPart);
        }
    }
}
