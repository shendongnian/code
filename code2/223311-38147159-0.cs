        static Metafile GetMetafile(System.Windows.Forms.IDataObject obj)
        {
            var iobj = (System.Runtime.InteropServices.ComTypes.IDataObject)obj;
            var etc = iobj.EnumFormatEtc(System.Runtime.InteropServices.ComTypes.DATADIR.DATADIR_GET);
            var pceltFetched = new int[1];
            var fmtetc = new System.Runtime.InteropServices.ComTypes.FORMATETC[1];
            while (0 == etc.Next(1, fmtetc, pceltFetched) && pceltFetched[0] == 1)
            {
                var et = fmtetc[0];
                var fmt = DataFormats.GetFormat(et.cfFormat);
                if (fmt.Name != "EnhancedMetafile")
		{
                    continue;
                }
                System.Runtime.InteropServices.ComTypes.STGMEDIUM medium;
                iobj.GetData(ref et, out medium);
                return new Metafile(medium.unionmember, true);
            }
            return null;
        }
 
    private void Panel_DragDrop(object sender, DragEventArgs e)
     {
    
     	if (e.Data.GetDataPresent(DataFormats.EnhancedMetafile) & e.Data.GetDataPresent(DataFormats.MetafilePict))
     	{
                        Metafile meta = GetMetafile(e.Data);
                        Image image = meta;
     	}
    }
