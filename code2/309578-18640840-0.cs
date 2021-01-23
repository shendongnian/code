            IEnumerable<int> shils =  new int[]{ 
                ShellAPI.SHIL_EXTRALARGE, 
                ShellAPI.SHIL_JUMBO, 
                ShellAPI.SHIL_SYSSMALL,
                ShellAPI.SHIL_LARGE, 
                ShellAPI.SHIL_SMALL,
                ShellAPI.SHIL_LAST
            };
            ShellAPI.IImageList ppv = null;
            Guid guil = new Guid(IID_IImageList2);//or IID_IImageList
            foreach (int iil in shils)
            {
                ShellAPI.SHGetImageList(iil, ref guil, ref ppv);
                int noImages = 0;
                ppv.GetImageCount(ref noImages);
                //...
            }
