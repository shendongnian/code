using System.Collections.Generic;
using UnityEngine;
using System;
public enum ColorSelection { Slime, Salmon, Marine, Dusk }
[Serializable] public class ColorSet { public ColorSelection unit; }
public class InputManager : MonoBehaviour
{
    public ColorPicker cPicker;
    public GameObject Robot;
    public ColorSet color;
    private ColorType GetColorType(ColorSelection colorSelection, ColorPicker colorPicker)
    {
        switch (colorSelection)
        {
            case ColorSelection.Slime:
                return colorPicker.Slime;
            case ColorSelection.Salmon:
                return colorPicker.Salmon;
            case ColorSelection.Marine:
                return colorPicker.Marine;
            case ColorSelection.Dusk:
                return colorPicker.Dusk;
            default:
                throw new ArgumentOutOfRangeException(nameof(colorSelection), colorSelection, null);
        }
    }
    
    public void Update()
    {
        var colorType = GetColorType(color.unit, cPicker);
        Robot.GetComponent<SpriteRenderer>().sprite = colorType.Chenilles;
        Robot.transform.Find("Middle").gameObject.GetComponent<SpriteRenderer>().sprite = colorType.Cover;
        Robot.transform.Find("Corps").gameObject.GetComponent<SpriteRenderer>().sprite = colorType.Head;
    }
}
as a bonus, in C# 8.0 this can be reduced to a switch expression, making it even more concise:
private ColorType GetColorType(ColorSelection colorSelection, ColorPicker colorPicker) =>
    colorSelection switch
    {
        ColorSelection.Slime => colorPicker.Slime,
        ColorSelection.Salmon => colorPicker.Salmon,
        ColorSelection.Marine => colorPicker.Marine,
        ColorSelection.Dusk => colorPicker.Dusk,
        _ => throw new ArgumentOutOfRangeException(nameof(colorSelection), colorSelection, null)
    };
`
