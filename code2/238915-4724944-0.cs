public event InitDragDropHandler InitDragDrop;
public delegate void InitDragDropHandler(object sender, object data);
public main()
{
	this.InitDragDrop += new InitDragDropHandler(main_InitDragDrop);
}
void mappoint_BeforeClick(object sender, AxMapPoint._IMappointCtrlEvents_BeforeClickEvent e)
{
	if (InitDragDrop != null)
	{
		this.BeginInvoke(new ThreadStart(() =>
			{
				InitDragDrop(mappoint, pps);
			}));
	}
}
void main_InitDragDrop(object sender, object data)
{
	((Control)sender).DoDragDrop(data, DragDropEffects.Copy);
}
