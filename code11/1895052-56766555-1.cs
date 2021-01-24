csharp
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HumanBodyPart
{
    public string EnglishTitle;
    public List<HumanBodyPart> SubParts;
    public bool IsExpanded;
    public int DrawDepth;
    public HumanBodyPart(string title, HumanBodyPart[] subParts)
    {
        this.EnglishTitle = title;
        this.SubParts = new List<HumanBodyPart>();
        this.SubParts.AddRange(subParts);
        this.IsExpanded = false;
        this.DrawDepth = 0;
    }
}
public class Script : MonoBehaviour 
{
    [SerializeField]
    Text text;
    HumanBodyPart mainBodyPart;
    private void Start()
    {
        HumanBodyPart subSubSubBodyPart = new HumanBodyPart("SubSubSubBodyPart", new HumanBodyPart[] { });
        HumanBodyPart subSubBodyPart1 = new HumanBodyPart("SubSubBodyPart1", new HumanBodyPart[] { subSubSubBodyPart });
        HumanBodyPart subSubBodyPart2 = new HumanBodyPart("SubSubBodyPart2", new HumanBodyPart[] { });
        HumanBodyPart subBodyPart = new HumanBodyPart("SubBodyPart", new HumanBodyPart[] { subSubBodyPart1, subSubBodyPart2});
        mainBodyPart = new HumanBodyPart("BodyPart", new HumanBodyPart[] { subBodyPart });
        UpdateDrawDepths(mainBodyPart);
    }
    private void UpdateDrawDepths(HumanBodyPart currentBodyPart, int currentDrawDepth=0)
    {
        currentBodyPart.DrawDepth = currentDrawDepth;
        foreach (HumanBodyPart bodyPart in currentBodyPart.SubParts)
        {
            UpdateDrawDepths(bodyPart, currentDrawDepth + 1);
        }
    }
    private void OnGUI()
    {
        float spacing = 30;
        float x = text.transform.position.x + spacing;
        float y = text.transform.position.y;
        int drawDepth = 0;
        List<HumanBodyPart> nextPartsToRender = new List<HumanBodyPart>(new HumanBodyPart[] { mainBodyPart });
        while (nextPartsToRender.Count > 0)
        {
            HumanBodyPart currentPart = nextPartsToRender[0];
            GUI.Label(new Rect(currentPart.DrawDepth * spacing + x, y, 200, 20), currentPart.EnglishTitle);
            nextPartsToRender.RemoveAt(0);
            if (GUI.Button(new Rect(x - spacing + currentPart.DrawDepth * spacing, y, 20, 20), "+"))
            {
                currentPart.IsExpanded = true;
            }
            if (currentPart.IsExpanded)
            {
                nextPartsToRender.InsertRange(0, currentPart.SubParts);
            }
            y += spacing;
        }
    }
}
[![example code UI expanded][1]][1]
  [1]: https://i.stack.imgur.com/zelUu.png
