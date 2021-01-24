 lang-c#
void Main()
{
	var vApp = MyExtensions.GetRunningVisio();
	for (int i = 1; i <= 4; i++)
	{
		var shp = vApp.ActivePage.Shapes.ItemFromID[i];
		var colorInfos = new List<ColorInfo>();
		colorInfos.Add(new ColorInfo(shp.CellsU["FillForegnd"]));
		colorInfos.Add(new ColorInfo(shp.CellsU["FillBkgnd"]));
		new
		{
			shp.NameID,
			FillPattern = shp.CellsU["FillPattern"].ResultIU,
			FillGradientEnabled = Convert.ToBoolean(shp.CellsU["FillGradientEnabled"].ResultIU),
			PatternColors = colorInfos,
			GradientColors = FillGradientColors(shp) ?? "Default (10 stops all white)"
		}.Dump();
	}
}
private dynamic FillGradientColors(Visio.Shape shp)
{
	List<string> rgbs = null;
	var iSect = (short)Visio.VisSectionIndices.visSectionFillGradientStops;
	for (int i = 0; i < shp.RowCount[iSect]; i++)
	{
		var targetCell = shp.CellsSRC[iSect, (short)i, (short)Visio.VisCellIndices.visGradientStopColor];
		if (targetCell.IsInherited == 0)
		{
			if (rgbs is null)
			{
				rgbs = new List<string>();
			}
			rgbs.Add(ColorInfo.RgbString(targetCell));
		}
	}	
	return rgbs;	
}
public class ColorInfo
{
	private Visio.Cell _vCell;
	
	public ColorInfo(Visio.Cell vCell)
	{
		_vCell = vCell;
		RGB = RgbString(_vCell);
	}
	
	public string Name => _vCell.Name;
	public string RGB { get; set; }
	public string FormulaU => _vCell.FormulaU;
	
	public static string RgbString(Visio.Cell cell)
	{
		var colorIdx = cell.Result[(short)Visio.VisUnitCodes.visUnitsColor];
		var c = cell.Document.Colors.Item16[(short)colorIdx];
		return $"RGB({c.Red},{c.Green},{c.Blue})";
	}
}
... this produces the following output:
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/KcdCX.png
  [2]: https://i.stack.imgur.com/Pcd8F.png
