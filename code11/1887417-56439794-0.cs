private static IDictionary<string, StatusColor> _statusColorByHtml = Enum.GetValues(typeof(StatusColor)).Cast<StatusColor>().ToDictionary(k => k.GetStringValue(), v => v);
public static StatusColor GetStatusColor(string htmlColor)
{
	_statusColorByHtml.TryGetValue(htmlColor, out StatusColor color);
	return color;
}
