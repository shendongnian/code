    var longest = Items.Max( w => w.RenatlUnit == null
                                      || w.RenatlUnit.UnitNumber == null)
                                  ? 0
                                  : w.RenatlUnit.UnitNumber.Length );
    if (longest == 0)
    {
        return 2;
    }
    return TextRenderer.MeasureText( new String('0', longest ) ).Width + 2;
