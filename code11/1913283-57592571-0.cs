	public Form1()
	{
		InitializeComponent();
		
		tlv.IsSimpleDropSink = true;
		olv.IsSimpleDragSource = true;
		olv.AddObject("Fish");
		tlv.ModelCanDrop += (s,e)=>{e.Effect = DragDropEffects.Copy;};
		tlv.ModelDropped += Tlv_ModelDropped;
	}
	private void Tlv_ModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
	{
		foreach(var m in e.SourceModels)
			((TreeListView)sender).AddObject(m);
	}
